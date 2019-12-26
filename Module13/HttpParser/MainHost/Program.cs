using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteCopier;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "https://pikabu.ru/";
            DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            var pathToSaveSite = projectDirectory.FullName + @"\PathToSaveSite\";
            var pathToSaveFiles = projectDirectory.FullName + @"\PathToSaveSite\files\";
            Copier copier = new Copier(address, pathToSaveSite, pathToSaveFiles);
            copier.SaveSiteCopy();

            Console.ReadLine();
        }
    }
}
