using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            //string s = con.WatcherFolder.FolderToWatch;
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

                watcher.Filter = "*.txt";
               

                watcher.Created += OnChanged;
                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press q to quit the Program");
                while (Console.Read() != 'q');
            }
            
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.FullPath} is {e.ChangeType}");
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File {e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
