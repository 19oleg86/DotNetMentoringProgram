using System;
using System.Collections;
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
            BuildTreeWithEnumerator();
        }
        public FileSystemVisitor()
        {
        }

        public void ScanDirectoies(string wayToDirOrFile)
        {
            string[] dirsAndFiles = Directory.GetFileSystemEntries(wayToDirOrFile);
            foreach (string dirOrFile in dirsAndFiles)
            {
                int index = dirOrFile.IndexOf("BaseDirectory");
                treeListBox.Items.Add(dirOrFile.Substring(index));
                if (Directory.Exists(dirOrFile))
                {
                    ScanDirectoies(dirOrFile);
                }

            }
        }
        string basePath = @"d:\Programming\CSharp\DotNetMentoringProgram\Module02\WinFormsApp\BaseDirectory\";
        int i;
        public IEnumerator GetEnumerator()
        {
            string[] dirsAndFiles = Directory.GetFileSystemEntries(basePath);
            for (i = 0; i < dirsAndFiles.Length; i++)
            {
                if(Directory.Exists(dirsAndFiles[i]))
                {
                    basePath = dirsAndFiles[i];
                }
                yield return dirsAndFiles[i];
            }
        }

        public void BuildTreeWithEnumerator()
        {
            FileSystemVisitor fsv = new FileSystemVisitor();
            foreach (string result in fsv)
            {
                treeIteratorListBox.Items.Add(result);
            }

        }
    }
}
