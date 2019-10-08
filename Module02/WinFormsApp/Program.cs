using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = @"d:\Programming\CSharp\DotNetMentoringProgram\Module02\WindowsForms\WinFormsApp\BaseDirectory\";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileSystemVisitor(path));

            //string path = @"d:\Programming\CSharp\DotNetMentoringProgram\Module02\WindowsForms\WinFormsApp\BaseDirectory\";
            //FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(path);
            //fileSystemVisitor.ScanDirectoies();
        }
    }
}
