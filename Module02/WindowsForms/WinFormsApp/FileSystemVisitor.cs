using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FileSystemVisitor : Form
    {
        private string path;
        public FileSystemVisitor(string path)
        {
            InitializeComponent();
            this.path = path;
            ScanDirectoies(this.path);
        }
        
        public void ScanDirectoies(string wayToDirOrFile)
        {
            string[] dirsAndFiles = Directory.GetFileSystemEntries(wayToDirOrFile);
            foreach(string dirOrFile in dirsAndFiles)
            {
                int index = dirOrFile.IndexOf("BaseDirectory");
                treeListBox.Items.Add(dirOrFile.Substring(index));
                if (Directory.Exists(dirOrFile))
                {
                    ScanDirectoies(dirOrFile);
                }

            }
        }


    }
}
