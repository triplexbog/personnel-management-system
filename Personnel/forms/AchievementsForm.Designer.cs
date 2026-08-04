partial class AchievementsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dataGridViewAchievements;
    private System.Windows.Forms.Button btnAddAchievement;

    private void InitializeComponent()
    {
            this.dataGridViewAchievements = new System.Windows.Forms.DataGridView();
            this.btnAddAchievement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAchievements)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAchievements
            // 
            this.dataGridViewAchievements.AllowUserToAddRows = false;
            this.dataGridViewAchievements.AllowUserToDeleteRows = false;
            this.dataGridViewAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAchievements.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAchievements.Name = "dataGridViewAchievements";
            this.dataGridViewAchievements.ReadOnly = true;
            this.dataGridViewAchievements.Size = new System.Drawing.Size(660, 300);
            this.dataGridViewAchievements.TabIndex = 0;
            this.dataGridViewAchievements.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAchievements_CellContentClick);
            // 
            // btnAddAchievement
            // 
            this.btnAddAchievement.Location = new System.Drawing.Point(12, 325);
            this.btnAddAchievement.Name = "btnAddAchievement";
            this.btnAddAchievement.Size = new System.Drawing.Size(150, 30);
            this.btnAddAchievement.TabIndex = 1;
            this.btnAddAchievement.Text = "Добавить достижение";
            this.btnAddAchievement.UseVisualStyleBackColor = true;
            this.btnAddAchievement.Click += new System.EventHandler(this.btnAddAchievement_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Двойной клик для открытия документов";
            // 
            // AchievementsForm
            // 
            this.ClientSize = new System.Drawing.Size(684, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAchievements);
            this.Controls.Add(this.btnAddAchievement);
            this.Name = "AchievementsForm";
            this.Text = "Учёт достижений";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAchievements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private System.Windows.Forms.Label label1;
}
