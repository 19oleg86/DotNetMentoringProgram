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
        List<string> allPathes;

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
            allPathes = new List<string>();
        }

        public List<string> StartSearch(string wayToDirOrFile, Func<string, bool> predicate)
        {
            LogStart("Search has started");
            allPathes.AddRange(ScanDirectoies(wayToDirOrFile, predicate));
            LogFinish("Search has finished");
            return allPathes;
        }
        private List<string> ScanDirectoies(string wayToDirOrFile, Func<string, bool> predicate)
        {
            string[] dirsAndFiles = Directory.GetFileSystemEntries(wayToDirOrFile);
            foreach (string dirOrFile in dirsAndFiles)
            {
                if (predicate(dirOrFile))
                {
                    allPathes.Add(dirOrFile);
                    LogFoundItem?.Invoke(this, new EventArgs("New directory or file founded: ", dirOrFile));
                    if (Directory.Exists(dirOrFile))
                    {
                        ScanDirectoies(dirOrFile, predicate);
                    }
                }
            }
            return allPathes;
        }

        public void CheckAndLogFilteredData(string filteredPath)
        {
            LogFoundFilteredItem?.Invoke(this, new EventArgs("Filtered directory or file founded: ", filteredPath));
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
