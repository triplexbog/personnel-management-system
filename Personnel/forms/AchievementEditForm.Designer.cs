partial class AchievementEditForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.ComboBox comboLevel;
    private System.Windows.Forms.DateTimePicker dateEvent;
    private System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnAttachDocument;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.PictureBox picturePreview;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblLevel;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label lblResult;

    private void InitializeComponent()
    {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.dateEvent = new System.Windows.Forms.DateTimePicker();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnAttachDocument = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(147, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // comboLevel
            // 
            this.comboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevel.Location = new System.Drawing.Point(147, 52);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(250, 21);
            this.comboLevel.TabIndex = 5;
            // 
            // dateEvent
            // 
            this.dateEvent.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEvent.Location = new System.Drawing.Point(147, 92);
            this.dateEvent.Name = "dateEvent";
            this.dateEvent.Size = new System.Drawing.Size(250, 20);
            this.dateEvent.TabIndex = 6;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(147, 132);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(250, 20);
            this.txtResult.TabIndex = 7;
            // 
            // btnAttachDocument
            // 
            this.btnAttachDocument.Location = new System.Drawing.Point(12, 180);
            this.btnAttachDocument.Name = "btnAttachDocument";
            this.btnAttachDocument.Size = new System.Drawing.Size(150, 30);
            this.btnAttachDocument.TabIndex = 8;
            this.btnAttachDocument.Text = "Прикрепить документ";
            this.btnAttachDocument.Click += new System.EventHandler(this.btnAttachDocument_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(227, 180);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(170, 150);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePreview.TabIndex = 9;
            this.picturePreview.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(12, 55);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(100, 23);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "Уровень:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 95);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Дата:";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(12, 135);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(100, 23);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Результат:";
            // 
            // AchievementEditForm
            // 
            this.ClientSize = new System.Drawing.Size(512, 390);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.comboLevel);
            this.Controls.Add(this.dateEvent);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnAttachDocument);
            this.Controls.Add(this.picturePreview);
            this.Controls.Add(this.btnSave);
            this.Name = "AchievementEditForm";
            this.Text = "Добавить достижение";
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
