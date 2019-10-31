using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ResourceManager resourceManager;
            string userChoice = string.Empty;
            do
            {
                Console.WriteLine("Please choose interface language: E - for English, R - for Russian");
                userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "E")
                {
                    resourceManager = new ResourceManager("ConsApp.Properties.Resources", typeof(Program).Assembly);
                }
                else if (userChoice == "R")
                {
                    resourceManager = new ResourceManager("ConsApp.Properties.Resources-RU", typeof(Program).Assembly);
                }
                else
                {
                    resourceManager = null;
                    Console.WriteLine("You can choose only E - for English language interface or R - for Russian language interface");
                    Console.WriteLine();
                }
            } while (resourceManager == null);
            
            var con = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = con.WatcherFolder.FolderToWatch;
                watcher.NotifyFilter = NotifyFilters.Attributes
                    | NotifyFilters.CreationTime
                    | NotifyFilters.DirectoryName
                    | NotifyFilters.FileName
                    | NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.Size;

                watcher.Filter = "*";

                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.Clear();
                Console.WriteLine(resourceManager.GetString("programGoal"));
                Console.WriteLine();
                Console.WriteLine(resourceManager.GetString("toExit"));
                Console.WriteLine();
                while (Console.Read() != 'q') ;
            }
        }

        private static string GetFilterString(CustomConfigurationSection section)
        {
            return string.Join("|", section.Files.OfType<FileElement>().Select(i => i.FileType));
        }

        private static void LogAndMoveFile(string message, string finalDestination, string movingFile)
        {
            Console.WriteLine(message);
            File.Move(movingFile, finalDestination);
            File.Delete(movingFile);
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {

            var configuration = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            string fileToCheck = e.FullPath;
            if (!File.Exists(configuration.TargetFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1)) &&
                !File.Exists(configuration.DefaultFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1)))
            {
                Console.WriteLine($"File {e.FullPath} is {e.ChangeType}");

                string setOfRegExpressions = GetFilterString(configuration);

                if (Regex.IsMatch(fileToCheck, setOfRegExpressions, RegexOptions.IgnoreCase))
                {
                    LogAndMoveFile("The rule is found and this file is moved to \"TargetFolder\" directory",
                                    configuration.TargetFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1),
                                    fileToCheck);
                }
                else
                {
                    LogAndMoveFile("The rule isn't found and this file is moved to \"DefaultFolder\" directory",
                                    configuration.DefaultFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1),
                                    fileToCheck);
                }
            }
            else
            {
                Console.WriteLine("File with this name already exists - create another file");
                File.Delete(fileToCheck);
            }
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.FullPath} is {e.ChangeType}");
            Console.WriteLine();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File {e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
