using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    enum Pathes
    {
        BaseDirectory,
        Catalog1,
        Catalog2,
        Catalog3,
        Catalog4
    }
    class Program
    {
        static void Main(string[] args)
        {
            string directoryName = @"d:\Programming\CSharp\DotNetMentoringProgram\Module02\ConsoleApp\BaseDirectory\";
            IEnumerable<string> directiesAndFiles =  Directory.EnumerateFileSystemEntries(directoryName);
            foreach (var directoryAndFile in directiesAndFiles)
            {
                Console.WriteLine(directoryAndFile);
            }
            
            //DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);


            //DirectoryInfo[] directories = directoryInfo.GetDirectories();

            //FileInfo[] files = directoryInfo.GetFiles();

            //foreach (var dir in directories)
            //{
            //    int baseDirectoryIndex = dir.FullName.IndexOf("BaseDirectory");
            //    Console.WriteLine(dir.FullName.Substring(baseDirectoryIndex));
            //    foreach (var file in files)
            //    {
            //        int fileNameIndex = file.FullName.IndexOf("BaseDirectory");
            //        Console.WriteLine(file.FullName.Substring(fileNameIndex));
            //    }
            //}

        }
    }
}
