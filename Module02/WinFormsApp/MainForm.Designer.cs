namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeListBox = new System.Windows.Forms.ListBox();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.lblTreeDirectoriesBinding = new System.Windows.Forms.Label();
            this.lblLogging = new System.Windows.Forms.Label();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeListBox
            // 
            this.treeListBox.FormattingEnabled = true;
            this.treeListBox.HorizontalScrollbar = true;
            this.treeListBox.Location = new System.Drawing.Point(12, 84);
            this.treeListBox.Name = "treeListBox";
            this.treeListBox.Size = new System.Drawing.Size(580, 485);
            this.treeListBox.TabIndex = 0;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.HorizontalScrollbar = true;
            this.logListBox.Location = new System.Drawing.Point(630, 84);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(662, 485);
            this.logListBox.TabIndex = 1;
            // 
            // lblTreeDirectoriesBinding
            // 
            this.lblTreeDirectoriesBinding.AutoSize = true;
            this.lblTreeDirectoriesBinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreeDirectoriesBinding.Location = new System.Drawing.Point(204, 49);
            this.lblTreeDirectoriesBinding.Name = "lblTreeDirectoriesBinding";
            this.lblTreeDirectoriesBinding.Size = new System.Drawing.Size(164, 17);
            this.lblTreeDirectoriesBinding.TabIndex = 2;
            this.lblTreeDirectoriesBinding.Text = "Tree Directories Building";
            // 
            // lblLogging
            // 
            this.lblLogging.AutoSize = true;
            this.lblLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogging.Location = new System.Drawing.Point(892, 49);
            this.lblLogging.Name = "lblLogging";
            this.lblLogging.Size = new System.Drawing.Size(59, 17);
            this.lblLogging.TabIndex = 3;
            this.lblLogging.Text = "Logging";
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterButton.Location = new System.Drawing.Point(12, 583);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(128, 20);
            this.filterButton.TabIndex = 6;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(165, 583);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(145, 20);
            this.filterTextBox.TabIndex = 7;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(265, 9);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(793, 20);
            this.pathTextBox.TabIndex = 8;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(50, 9);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(181, 23);
            this.pathButton.TabIndex = 9;
            this.pathButton.Text = "Choose the Directory";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 615);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.lblLogging);
            this.Controls.Add(this.lblTreeDirectoriesBinding);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.treeListBox);
            this.Name = "MainForm";
            this.Text = "FileSystemVisitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox treeListBox;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Label lblTreeDirectoriesBinding;
        private System.Windows.Forms.Label lblLogging;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button pathButton;
    }
}

