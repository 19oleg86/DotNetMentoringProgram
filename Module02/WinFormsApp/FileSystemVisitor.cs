using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    class FileSystemVisitor
    {
        MainForm mainForm;

        public delegate void TreeStateHandler(string message);

        public delegate void TreeStateHandlerWithInfo(object sender, EventArgs e);

        public delegate void FilteredTreeStateHandler(string unit);

        public delegate void FilteredTreeStateHandlerWithInfo(object sender, EventArgs e);

        public event TreeStateHandler LogStart;

        public event TreeStateHandler LogFinish;

        public event TreeStateHandlerWithInfo LogFoundItem;

        public event FilteredTreeStateHandlerWithInfo LogFoundFilteredItem;

        public FileSystemVisitor()
        {
            mainForm = new MainForm();
        }

        public void ScanDirectoies(string wayToDirOrFile, Func<string, bool> predicate)
        {
            if (LogStart != null &&  mainForm.LogListBox.Items.Count == 0)
            {
                LogStart("Search has started");
            }
            string[] dirsAndFiles = Directory.GetFileSystemEntries(wayToDirOrFile);
            foreach (string dirOrFile in dirsAndFiles)
            {
                int index = dirOrFile.IndexOf("BaseDirectory");
                if (predicate(dirOrFile))
                {
                    mainForm.TreeListBox.Items.Add(dirOrFile.Substring(index));
                }

                LogFoundItem?.Invoke(this, new EventArgs("New directory or file founded: ", dirOrFile.Substring(index)));
                if (Directory.Exists(dirOrFile))
                {
                    ScanDirectoies(dirOrFile, predicate);
                }
            }
            if (LogFinish != null && !mainForm.LogListBox.Items.Contains("Search has finished"))
            {
                LogFinish("Search has finished");
            }
        }
        private void filterButton_Click(object sender, System.EventArgs e)
        {
            mainForm.FilteredResultsListBox.Items.Clear();
            mainForm.LogListBox.Items.Clear();
            FilteredTreeStateHandler filteredTreeStateHandler = mes =>
            {
                foreach (string fileOrDirectory in mainForm.TreeListBox.Items)
                {
                    if (fileOrDirectory.ToUpper().Contains(mes.ToUpper()))
                    {
                        int index = fileOrDirectory.IndexOf("BaseDirectory");
                        mainForm.FilteredResultsListBox.Items.Add(fileOrDirectory);
                        LogFoundFilteredItem?.Invoke(this, new EventArgs("Filtered directory or file founded: ", fileOrDirectory.Substring(index)));
                    }
                }
            };
            filteredTreeStateHandler(mainForm.FilterTextBox.Text);
        }
    }
    public class EventArgs
    {
        public string Message { get; }
        public string ItemInfo { get; }

        public EventArgs(string mes, string info)
        {
            Message = mes;
            ItemInfo = info;
        }
    }
}
