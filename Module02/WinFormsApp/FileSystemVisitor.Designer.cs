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
            this.treeIteratorListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // treeListBox
            // 
            this.treeListBox.FormattingEnabled = true;
            this.treeListBox.Location = new System.Drawing.Point(12, 12);
            this.treeListBox.Name = "treeListBox";
            this.treeListBox.Size = new System.Drawing.Size(320, 537);
            this.treeListBox.TabIndex = 0;
            // 
            // treeIteratorListBox
            // 
            this.treeIteratorListBox.FormattingEnabled = true;
            this.treeIteratorListBox.Location = new System.Drawing.Point(338, 12);
            this.treeIteratorListBox.Name = "treeIteratorListBox";
            this.treeIteratorListBox.Size = new System.Drawing.Size(614, 537);
            this.treeIteratorListBox.TabIndex = 1;
            // 
            // FileSystemVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 639);
            this.Controls.Add(this.treeIteratorListBox);
            this.Controls.Add(this.treeListBox);
            this.Name = "FileSystemVisitor";
            this.Text = "FileSystemVisitor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox treeListBox;
        private System.Windows.Forms.ListBox treeIteratorListBox;
    }
}

