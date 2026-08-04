namespace PersonnelApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnProfiles;
        private System.Windows.Forms.Button btnAchievements;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnProfiles = new System.Windows.Forms.Button();
            this.btnAchievements = new System.Windows.Forms.Button();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            // 
            // lblWelcome
            // 
            this.lblWelcome.Text = "Панель управления";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.AutoSize = true;

            // 
            // btnProfiles
            // 
            this.btnProfiles.Text = "Профили";
            this.btnProfiles.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProfiles.Size = new System.Drawing.Size(180, 40);
            this.btnProfiles.Location = new System.Drawing.Point(30, 80);
            this.btnProfiles.Click += new System.EventHandler(this.btnProfiles_Click);

            // 
            // btnAchievements
            // 
            this.btnAchievements.Text = "Достижения";
            this.btnAchievements.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAchievements.Size = new System.Drawing.Size(180, 40);
            this.btnAchievements.Location = new System.Drawing.Point(30, 130);
            this.btnAchievements.Click += new System.EventHandler(this.btnAchievements_Click);

            // 
            // btnDocuments
            // 
            this.btnDocuments.Text = "Документы";
            this.btnDocuments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDocuments.Size = new System.Drawing.Size(180, 40);
            this.btnDocuments.Location = new System.Drawing.Point(30, 180);
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);

            // 
            // btnReports
            // 
            this.btnReports.Text = "Отчёты";
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReports.Size = new System.Drawing.Size(180, 40);
            this.btnReports.Location = new System.Drawing.Point(30, 230);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // 
            // btnUsers
            // 
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUsers.Size = new System.Drawing.Size(180, 40);
            this.btnUsers.Location = new System.Drawing.Point(30, 280);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);

            // 
            // btnExit
            // 
            this.btnExit.Text = "Выход";
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.Size = new System.Drawing.Size(180, 40);
            this.btnExit.Location = new System.Drawing.Point(30, 330);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(260, 400);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnProfiles);
            this.Controls.Add(this.btnAchievements);
            this.Controls.Add(this.btnDocuments);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная панель";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
