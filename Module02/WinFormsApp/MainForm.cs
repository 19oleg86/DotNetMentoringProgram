﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            groupBoxShowWhat.Controls.Add(radioButtonDirectories);
            groupBoxShowWhat.Controls.Add(radioButtonFileNames);
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            visitor = new FileSystemVisitor();
            visitor.LogStart += ShowLogMessage;
            visitor.LogFinish += ShowLogMessage;
            visitor.LogFoundItem += ShowLogMessageWithInfo;
            visitor.LogFoundFilteredItem += ShowLogMessageWithInfo;
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
        public bool MyCondition(string returnedPath)
        {
            bool result = false;
            if (returnedPath.ToUpper().Contains(filterTextBox.Text.ToUpper()) && filterTextBox.Text != "")
            {
                result = true;
            }
            return result;
        }
        private void filterButton_Click(object sender, System.EventArgs e)
        {
            if (Directory.Exists(path))
            {
                returnedPathes.Clear();
                treeListBox.Items.Clear();
                returnedPathes.AddRange(visitor.StartSearch(path, MyCondition));
                foreach (string path in returnedPathes)
                {
                    if (radioButtonDirectories.Checked == true)
                    {
                        if (Directory.Exists(path))
                        {
                            treeListBox.Items.Add(path);
                        }
                    }
                    else if(radioButtonFileNames.Checked == true)
                    {
                        if (File.Exists(path))
                        {
                            treeListBox.Items.Add(path);
                        }
                    }
                    else
                    { 
                        treeListBox.Items.Add(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong or Empty Directory, Choose the real Directory first!");
            }
        }

        public void ShowLogMessage(string message)
        {
            logListBox.Items.Add(message);
        }

        public void ShowLogMessageWithInfo(object sender, EventArgs e)
        {
            logListBox.Items.Add($"{e.Message} {e.ItemInfo}");
            if (checkBoxStopSearching.Checked == true)
            {
                if (e.ItemInfo.Contains(".txt"))
                {
                    visitor.ShouldStop = true;
                }
            }
        }
        private void PathButton_Click(object sender, System.EventArgs e)
        {
            InvokeFolderBrowserDialog();
        }
        private void pathTextBox_TextChanged(object sender, System.EventArgs e)
        {
            path = pathTextBox.Text;
        }
        private void buttonClearBoth_Click(object sender, System.EventArgs e)
        {
            radioButtonDirectories.Checked = false;
            radioButtonFileNames.Checked = false;
        }
    }
}
