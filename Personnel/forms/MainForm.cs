// Forms/MainForm.cs
using System;
using System.Windows.Forms;
using Personnel;
using Personnel.forms;

namespace PersonnelApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfiles_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие формы профилей...");
            ProfileListForm profileListForm = new ProfileListForm();
            profileListForm.ShowDialog();
        }

        private void btnAchievements_Click(object sender, EventArgs e)
        {
            int profileId = Program.CurrentUserId;
            AchievementsForm achievementsForm = new AchievementsForm(profileId);
            achievementsForm.ShowDialog();
            MessageBox.Show("Открытие формы достижений...");
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            DocumentsForm documentsForm = new DocumentsForm();
            documentsForm.ShowDialog();
            MessageBox.Show("Открытие формы документов...");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
            MessageBox.Show("Открытие формы отчетов...");
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.ShowDialog();
            MessageBox.Show("Открытие формы пользователей...");
        }
    }
}
