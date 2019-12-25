using System;
using System.IO;
using SiteCopier;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //string address = "https://www.w3schools.com";
            //DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            //var pathToSaveSite = projectDirectory.FullName + @"\PathToSaveSite\";
            //var pathToSaveCss = projectDirectory.FullName + @"\PathToSaveSite\style\";
            //var pathToSaveImages = projectDirectory.FullName + @"\PathToSaveSite\images\";
            //Copier copier = new Copier(address, pathToSaveSite, pathToSaveCss, pathToSaveImages);
            //copier.SaveSiteCopy();

            string address = "https://docs.microsoft.com/";
            DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            var pathToSaveSite = projectDirectory.FullName + @"\PathToSaveSite2\";
            Copier2 copier = new Copier2(address, pathToSaveSite/*, pathToSaveCss, pathToSaveImages*/);
            copier.SaveSiteCopyAsync();

            Console.WriteLine("Site is in saving process, you can chech PathToSaveSite directory in MainHost project");
            Console.ReadLine();
        }
    }
}
