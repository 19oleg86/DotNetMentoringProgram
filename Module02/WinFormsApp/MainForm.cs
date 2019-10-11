using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static WinFormsApp.FileSystemVisitor;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private string path;
        List<string> returnedPathes;
        private FileSystemVisitor visitor;
        public MainForm()
        {
            InitializeComponent();
            returnedPathes = new List<string>();
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            visitor = new FileSystemVisitor();
            visitor.LogStart += ShowLogMessage;
            visitor.LogFinish += ShowLogMessage;
            visitor.LogFoundItem += ShowLogMessageWithInfo;
            visitor.LogFoundFilteredItem += ShowLogMessageWithInfo;
            InvokeFolderBrowserDialog();
            returnedPathes.AddRange(visitor.StartSearch(path, MyCondition));
            foreach (string path in returnedPathes)
            {
                treeListBox.Items.Add(path);
                logListBox.Items.Add(path);
            }
        }

        public void InvokeFolderBrowserDialog()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                path = FBD.SelectedPath;
                pathTextBox.Text = FBD.SelectedPath;
            }
        }
        //public bool MyCondition(string path)
        //{
        //    var info = new DirectoryInfo(path);
        //    string[] allFilesAndDirs = Directory.GetFileSystemEntries(path);

        //    foreach (string st in allFilesAndDirs)
        //    {
        //        if (st == path)
        //        {
        //            return true;
        //        }
        //    }
        //}
        private void filterButton_Click(object sender, System.EventArgs e)
        {
            filteredResultsListBox.Items.Clear();
            logListBox.Items.Clear();
            FilteredTreeStateHandler filteredTreeStateHandler = mes =>
            {
                foreach (string fileOrDirectory in treeListBox.Items)
                {
                    if (fileOrDirectory.ToUpper().Contains(mes.ToUpper()))
                    {
                        filteredResultsListBox.Items.Add(fileOrDirectory);
                        visitor.CheckAndLogFilteredData(fileOrDirectory);
                    }
                }
            };
            filteredTreeStateHandler(filterTextBox.Text);
        }

        public void ShowLogMessage(string message)
        {
            logListBox.Items.Add(message);
        }

        public void ShowLogMessageWithInfo(object sender, EventArgs e)
        {
            logListBox.Items.Add($"{e.Message} {e.ItemInfo}");
        }

        private void PathButton_Click(object sender, System.EventArgs e)
        {
            InvokeFolderBrowserDialog();
        }
    }
}
