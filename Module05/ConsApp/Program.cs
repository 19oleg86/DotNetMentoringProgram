using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsApp
{
    class Program
    {
        private static ResourceManager resourceManager;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string userChoice = string.Empty;
            do
            {
                Console.WriteLine("Please choose interface language: E - for English, R - for Russian and press Enter");
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

            List<FileSystemWatcher> listWatchers = new List<FileSystemWatcher>()
            {
            new FileSystemWatcher(con.WatcherFolder.FolderToWatch),
            new FileSystemWatcher(con.WatcherFolderTwo.FolderToWatchTwo),
            new FileSystemWatcher(con.WatcherFolderThree.FolderToWatchThree),
            };

            do
            {
                foreach (var watcher in listWatchers)
                {
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
                }
            } while (Console.Read() != 'q');
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
                Console.WriteLine($"{resourceManager.GetString("File")} {e.FullPath} {resourceManager.GetString("Created")}");

                string setOfRegExpressions = GetFilterString(configuration);

                if (Regex.IsMatch(fileToCheck, setOfRegExpressions, RegexOptions.IgnoreCase))
                {
                    LogAndMoveFile(resourceManager.GetString("foundRule"),
                                    configuration.TargetFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1),
                                    fileToCheck);
                }
                else
                {
                    LogAndMoveFile(resourceManager.GetString("notFoundRule"),
                                    configuration.DefaultFolder.FolderToMove + fileToCheck.Substring(fileToCheck.LastIndexOf('\\') + 1),
                                    fileToCheck);
                }
            }
            else
            {
                Console.WriteLine(resourceManager.GetString("existingFile"));
                File.Delete(fileToCheck);
            }
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"{resourceManager.GetString("File")} {e.FullPath} {resourceManager.GetString("Deleted")}");
            Console.WriteLine();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"{resourceManager.GetString("File")} {e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
