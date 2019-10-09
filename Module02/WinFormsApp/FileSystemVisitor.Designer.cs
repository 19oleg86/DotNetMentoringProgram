﻿namespace WinFormsApp
{
    partial class FileSystemVisitor
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
            this.filteredResultsListBox = new System.Windows.Forms.ListBox();
            this.lblFilteredResults = new System.Windows.Forms.Label();
            this.filerButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeListBox
            // 
            this.treeListBox.FormattingEnabled = true;
            this.treeListBox.HorizontalScrollbar = true;
            this.treeListBox.Location = new System.Drawing.Point(12, 32);
            this.treeListBox.Name = "treeListBox";
            this.treeListBox.Size = new System.Drawing.Size(374, 537);
            this.treeListBox.TabIndex = 0;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.HorizontalScrollbar = true;
            this.logListBox.Location = new System.Drawing.Point(879, 32);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(553, 537);
            this.logListBox.TabIndex = 1;
            // 
            // lblTreeDirectoriesBinding
            // 
            this.lblTreeDirectoriesBinding.AutoSize = true;
            this.lblTreeDirectoriesBinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreeDirectoriesBinding.Location = new System.Drawing.Point(100, 9);
            this.lblTreeDirectoriesBinding.Name = "lblTreeDirectoriesBinding";
            this.lblTreeDirectoriesBinding.Size = new System.Drawing.Size(164, 17);
            this.lblTreeDirectoriesBinding.TabIndex = 2;
            this.lblTreeDirectoriesBinding.Text = "Tree Directories Building";
            // 
            // lblLogging
            // 
            this.lblLogging.AutoSize = true;
            this.lblLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogging.Location = new System.Drawing.Point(1107, 9);
            this.lblLogging.Name = "lblLogging";
            this.lblLogging.Size = new System.Drawing.Size(59, 17);
            this.lblLogging.TabIndex = 3;
            this.lblLogging.Text = "Logging";
            // 
            // filteredResultsListBox
            // 
            this.filteredResultsListBox.FormattingEnabled = true;
            this.filteredResultsListBox.HorizontalScrollbar = true;
            this.filteredResultsListBox.Location = new System.Drawing.Point(416, 32);
            this.filteredResultsListBox.Name = "filteredResultsListBox";
            this.filteredResultsListBox.Size = new System.Drawing.Size(436, 537);
            this.filteredResultsListBox.TabIndex = 4;
            // 
            // lblFilteredResults
            // 
            this.lblFilteredResults.AutoSize = true;
            this.lblFilteredResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilteredResults.Location = new System.Drawing.Point(561, 9);
            this.lblFilteredResults.Name = "lblFilteredResults";
            this.lblFilteredResults.Size = new System.Drawing.Size(106, 17);
            this.lblFilteredResults.TabIndex = 5;
            this.lblFilteredResults.Text = "Filtered Results";
            // 
            // filerButton
            // 
            this.filerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filerButton.Location = new System.Drawing.Point(12, 595);
            this.filerButton.Name = "filerButton";
            this.filerButton.Size = new System.Drawing.Size(128, 20);
            this.filerButton.TabIndex = 6;
            this.filerButton.Text = "Filter";
            this.filerButton.UseVisualStyleBackColor = true;
            this.filerButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(166, 595);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(145, 20);
            this.filterTextBox.TabIndex = 7;
            // 
            // FileSystemVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 639);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.filerButton);
            this.Controls.Add(this.lblFilteredResults);
            this.Controls.Add(this.filteredResultsListBox);
            this.Controls.Add(this.lblLogging);
            this.Controls.Add(this.lblTreeDirectoriesBinding);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.treeListBox);
            this.Name = "FileSystemVisitor";
            this.Text = "FileSystemVisitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox treeListBox;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Label lblTreeDirectoriesBinding;
        private System.Windows.Forms.Label lblLogging;
        private System.Windows.Forms.ListBox filteredResultsListBox;
        private System.Windows.Forms.Label lblFilteredResults;
        private System.Windows.Forms.Button filerButton;
        private System.Windows.Forms.TextBox filterTextBox;
    }
}

