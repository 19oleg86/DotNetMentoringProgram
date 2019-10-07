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
        DirectoryInfo directoryInfo;
        string iteratedPath;
        public FileSystemVisitor(string path)
        {
            InitializeComponent();
            directoryInfo = new DirectoryInfo(path);
            iteratedPath = path;
        }

        public void FolderSearch()
        {
            int iterator = 0;
            do
            {
                treeListBox.Items.AddRange(directoryInfo.GetDirectories());
                treeListBox.Items.AddRange(directoryInfo.GetFiles());
                directoryInfo = DirectoryIteration(treeListBox.Items[iterator].ToString());
                iterator++;
            }
            while (treeListBox.Items[iterator] != string.Empty);
        }

        public DirectoryInfo DirectoryIteration(string str)
        {
            iteratedPath = iteratedPath + @"\" + str;
            return new DirectoryInfo(iteratedPath);
        }

    }
}
