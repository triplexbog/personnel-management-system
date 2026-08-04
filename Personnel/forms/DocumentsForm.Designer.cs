using System;
using System.Windows.Forms;

namespace PersonnelApp
{
    partial class DocumentsForm : Form
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewDocuments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewFolders);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridViewDocuments);
            this.splitContainer.Panel2.Controls.Add(this.panelButtons);
            this.splitContainer.Size = new System.Drawing.Size(800, 450);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.TabIndex = 0;
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolders.Location = new System.Drawing.Point(0, 0);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(250, 450);
            this.treeViewFolders.TabIndex = 0;
            this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.Add(this.btnUpload);
            this.panelButtons.Controls.Add(this.btnDownload);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(10, 8);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Загрузить";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(100, 8);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Скачать";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(190, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewDocuments
            // 
            this.dataGridViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDocuments.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewDocuments.Name = "dataGridViewDocuments";
            this.dataGridViewDocuments.Size = new System.Drawing.Size(546, 410);
            this.dataGridViewDocuments.TabIndex = 2;
            this.dataGridViewDocuments.ReadOnly = true;
            this.dataGridViewDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocuments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocuments_CellDoubleClick);
            // 
            // DocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "DocumentsForm";
            this.Text = "Документооборот";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewDocuments;
    }
}