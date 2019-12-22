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
            string address = "https://www.w3schools.com/";
            DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            var pathToSaveSite = projectDirectory.FullName + @"\PathToSaveSite\";
            var pathToSaveCss = projectDirectory.FullName + @"\PathToSaveSite\style\";
            Copier copier = new Copier(address, pathToSaveSite, pathToSaveCss);
            copier.SaveSiteCopy();

            Console.ReadLine();
        }
    }
}
