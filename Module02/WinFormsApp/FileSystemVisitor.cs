using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FileSystemVisitor : Form
    {
        private string path;

        public delegate void TreeStateHandler(string message);

        public delegate void TreeStateHandlerWithInfo(object sender, AccountEventArgs e);

        public delegate void FilteredTreeStateHandler(string unit);

        public delegate void FilteredTreeStateHandlerWithInfo(object sender, AccountEventArgs e);

        public event TreeStateHandler LogStart;

        public event TreeStateHandler LogFinish;

        public event TreeStateHandlerWithInfo LogFoundItem;

        public event FilteredTreeStateHandlerWithInfo LogFoundFilteredItem;

        public FileSystemVisitor(string path)
        {
            InitializeComponent();
            this.path = path;
            LogStart += ShowLogMessage;
            LogFinish += ShowLogMessage;
            LogFoundItem += ShowLogMessageWithInfo;
            LogFoundFilteredItem += ShowLogMessageWithInfo;
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

        private void filterButton_Click(object sender, EventArgs e)
        {
            filteredResultsListBox.Items.Clear();
            logListBox.Items.Clear();
            FilteredTreeStateHandler filteredTreeStateHandler = mes =>
            {
                foreach (string fileOrDirectory in treeListBox.Items)
                {
                    if (fileOrDirectory.ToUpper().Contains(mes.ToUpper()))
                    {
                        int index = fileOrDirectory.IndexOf("BaseDirectory");
                        filteredResultsListBox.Items.Add(fileOrDirectory);
                        LogFoundFilteredItem?.Invoke(this, new AccountEventArgs("Filtered directory or file founded: ", fileOrDirectory.Substring(index)));
                    }
                }
            };
            filteredTreeStateHandler(filterTextBox.Text);
        }
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
