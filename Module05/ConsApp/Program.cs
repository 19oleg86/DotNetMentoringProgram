using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
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
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var rusCul = CultureInfo.GetCultureInfo("ru-Ru");
            var engCul = CultureInfo.GetCultureInfo("en-Us");

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
                
                watcher.Created += OnChanged;
                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("This program is watching a \"WatcherFolder\" directory for files: .txt, .docx, .rar and if they are found they will be removed to \"TargetFolder\" directory, " +
                    "any other files will be removed to \"DefaultFolder\" directory");
                Console.WriteLine();
                Console.WriteLine("Press q to quit the Program");
                while (Console.Read() != 'q');
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            var con = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            Console.WriteLine($"File {e.FullPath} is {e.ChangeType}");
            string strFileExt = e.FullPath;
            StringBuilder sb = new StringBuilder();
            foreach (FileElement file in con.Files)
            {
                sb.Append(file.FileType + "|");
            }
            string reStr = sb.ToString();
            string changedStr = reStr.Remove(reStr.LastIndexOf('|'));
            if (Regex.IsMatch(strFileExt, changedStr, RegexOptions.IgnoreCase) && e.ChangeType == WatcherChangeTypes.Created)
            {
                Console.WriteLine("The rule is found and this file will be moved to \"TargetFolder\" directory");
                string moveTo = con.TargetFolder.FolderToMove + strFileExt.Substring(strFileExt.LastIndexOf('\\') + 1);
                File.Move(strFileExt, moveTo);
                File.Delete(strFileExt);
            }
            else if (e.ChangeType == WatcherChangeTypes.Created)
            {
                Console.WriteLine("The rule isn't found and this file will be moved to \"DefaultFolder\" directory");
                string moveTo = con.DefaultFolder.FolderToMove + strFileExt.Substring(strFileExt.LastIndexOf('\\') + 1);
                File.Move(strFileExt, moveTo);
                File.Delete(strFileExt);
            }
            else { };
            Console.WriteLine();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File {e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
