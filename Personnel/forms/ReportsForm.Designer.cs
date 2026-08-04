namespace PersonnelApp.Forms
{
    partial class ReportsForm
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
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(12, 15);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(63, 13);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Тип отчёта:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Активные сотрудники",
            "Достижения за период",
            "Поощрения и взыскания"});
            this.cmbReportType.Location = new System.Drawing.Point(90, 12);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(200, 21);
            this.cmbReportType.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(310, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(21, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "С:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(335, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(450, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "По:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(485, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(600, 10);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(685, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewReports.TabIndex = 8;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblReportType);
            this.Name = "ReportsForm";
            this.Text = "Отчёты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dataGridViewReports;
    }
}
