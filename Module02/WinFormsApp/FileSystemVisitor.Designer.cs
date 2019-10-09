namespace WinFormsApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilteredResultsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filerButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeListBox
            // 
            this.treeListBox.FormattingEnabled = true;
            this.treeListBox.Location = new System.Drawing.Point(12, 32);
            this.treeListBox.Name = "treeListBox";
            this.treeListBox.Size = new System.Drawing.Size(374, 537);
            this.treeListBox.TabIndex = 0;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(904, 32);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(514, 537);
            this.logListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tree Directories Building";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1142, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Logging";
            // 
            // FilteredResultsListBox
            // 
            this.FilteredResultsListBox.FormattingEnabled = true;
            this.FilteredResultsListBox.Location = new System.Drawing.Point(416, 32);
            this.FilteredResultsListBox.Name = "FilteredResultsListBox";
            this.FilteredResultsListBox.Size = new System.Drawing.Size(436, 537);
            this.FilteredResultsListBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(561, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filtered Results";
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilteredResultsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox FilteredResultsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button filerButton;
        private System.Windows.Forms.TextBox filterTextBox;
    }
}

