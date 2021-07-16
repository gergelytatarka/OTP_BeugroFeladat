
using System;

namespace WinformsApplication
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxOfFiles = new System.Windows.Forms.ListBox();
            this.UploadFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ListBoxOfFiles
            // 
            this.ListBoxOfFiles.FormattingEnabled = true;
            this.ListBoxOfFiles.ItemHeight = 15;
            this.ListBoxOfFiles.Location = new System.Drawing.Point(2, 82);
            this.ListBoxOfFiles.Name = "ListBoxOfFiles";
            this.ListBoxOfFiles.Size = new System.Drawing.Size(225, 304);
            this.ListBoxOfFiles.TabIndex = 0;
            this.ListBoxOfFiles.DoubleClick += new System.EventHandler(this.ListBoxOfFiles_DoubleClick);
            // 
            // UploadFileButton
            // 
            this.UploadFileButton.Location = new System.Drawing.Point(85, 26);
            this.UploadFileButton.Name = "UploadFileButton";
            this.UploadFileButton.Size = new System.Drawing.Size(75, 23);
            this.UploadFileButton.TabIndex = 1;
            this.UploadFileButton.Text = "Upload file";
            this.UploadFileButton.UseVisualStyleBackColor = true;
            this.UploadFileButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Save as...";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 450);
            this.Controls.Add(this.UploadFileButton);
            this.Controls.Add(this.ListBoxOfFiles);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Winforms application";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxOfFiles;
        private System.Windows.Forms.Button UploadFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

