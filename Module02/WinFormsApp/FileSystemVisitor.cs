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

        public delegate void TreeStateHandler (string message);

        public delegate void TreeStateHandlerWithInfo(object sender, AccountEventArgs e);

        public delegate void FilteredTreeStateHandler(object sender, AccountEventArgs e);

        public event TreeStateHandler LogStart;

        public event TreeStateHandler LogFinish;

        public event TreeStateHandlerWithInfo LogFoundItem;

        public event FilteredTreeStateHandler FilterResults;

        public FileSystemVisitor(string path)
        {
            InitializeComponent();
            this.path = path;
            LogStart += ShowLogMessage;
            LogFinish += ShowLogMessage;
            LogFoundItem += ShowLogMessageWithInfo;
            ScanDirectoies(this.path);
        }

        public void ScanDirectoies(string wayToDirOrFile)
        {
            if (LogStart != null && logListBox.Items.Count == 0)
            {
                LogStart("Search has started");
            }
            string[] dirsAndFiles = Directory.GetFileSystemEntries(wayToDirOrFile);
            foreach (string dirOrFile in dirsAndFiles)
            {
                int index = dirOrFile.IndexOf("BaseDirectory");

                treeListBox.Items.Add(dirOrFile.Substring(index));

                LogFoundItem?.Invoke(this, new AccountEventArgs("New directory or file founded: ", dirOrFile.Substring(index)));
                if (Directory.Exists(dirOrFile))
                {
                    ScanDirectoies(dirOrFile);
                }  
            }
            if (LogFinish != null && !logListBox.Items.Contains("Search has finished"))
            {
                LogFinish("Search has finished");
            }
        }

        public void ShowLogMessage(string message)
        {
            logListBox.Items.Add(message);
        }

        public void ShowLogMessageWithInfo(object sender, AccountEventArgs e)
        {
            logListBox.Items.Add($"{e.Message} {e.ItemInfo}");
        }

        public class AccountEventArgs
        {
            public string Message { get; }
            public string ItemInfo { get; }

            public AccountEventArgs(string mes, string info)
            {
                Message = mes;
                ItemInfo = info;
            }
        }
    }
}
