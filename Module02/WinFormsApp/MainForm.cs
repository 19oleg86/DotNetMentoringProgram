using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private string path;
        private FileSystemVisitor visitor;
        public ListBox LogListBox { get { return logListBox; } set { logListBox = value; } }
        public ListBox TreeListBox { get { return treeListBox; } set { treeListBox = value; } }
        public ListBox FilteredResultsListBox { get { return filteredResultsListBox; } set { filteredResultsListBox = value; } }
        public TextBox FilterTextBox { get { return filterTextBox; } set { filterTextBox = value; } }

        public MainForm()
        {
            InitializeComponent();
            InvokeFDB();
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            visitor = new FileSystemVisitor();
            visitor.LogStart += ShowLogMessage;
            visitor.LogFinish += ShowLogMessage;
            visitor.LogFoundItem += ShowLogMessageWithInfo;
            visitor.LogFoundFilteredItem += ShowLogMessageWithInfo;
            visitor.ScanDirectoies(path, MyCondition);
        }

        public void InvokeFDB()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                path = FBD.SelectedPath;
                pathTextBox.Text = FBD.SelectedPath;
            }
        }
        public bool MyCondition(string filePath)
        {
            var info = new DirectoryInfo(path);
            return info.CreationTime.Day == DateTime.Now.Day;
        }
        public void ShowLogMessage(string message)
        {
            logListBox.Items.Add(message);
        }

        public void ShowLogMessageWithInfo(object sender, EventArgs e)
        {
            logListBox.Items.Add($"{e.Message} {e.ItemInfo}");
        }
    }
}
