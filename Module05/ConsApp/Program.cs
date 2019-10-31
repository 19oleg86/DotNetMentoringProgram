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
            //var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //var rusCul = CultureInfo.GetCultureInfo("ru-Ru");
            //var engCul = CultureInfo.GetCultureInfo("en-Us");

            //var rm = new ResourceManager("ConsApp.Resources.Resources.en-US", typeof(Program).Assembly);
            //Console.WriteLine(rm.GetString("Hello")); 

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

                Console.WriteLine("This program is watching a \"WatcherFolder\" directory for files: .txt, .docx, .rar and if they are found they will be removed to \"TargetFolder\" directory, " +
                    "any other files will be removed to \"DefaultFolder\" directory");
                Console.WriteLine();
                Console.WriteLine("Press q to quit the Program");
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
