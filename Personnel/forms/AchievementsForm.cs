using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PersonnelApp.Helpers;

public partial class AchievementsForm : Form
{
    private string connectionString = DbConnectionHelper.GetConnectionString();
    private int profileId; // передаётся извне

    public AchievementsForm(int profileId)
    {
        InitializeComponent();
        this.profileId = profileId;
        LoadAchievements();
    }

    private void LoadAchievements()
    {
        dataGridViewAchievements.Columns.Clear(); // очищаем старые столбцы
        dataGridViewAchievements.Rows.Clear();    // очищаем старые строки

        // Добавляем столбцы вручную
        dataGridViewAchievements.Columns.Add("Title", "Название");
        dataGridViewAchievements.Columns.Add("Level", "Уровень");
        dataGridViewAchievements.Columns.Add("EventDate", "Дата");
        dataGridViewAchievements.Columns.Add("Result", "Результат");
        dataGridViewAchievements.Columns.Add("Docs", "Документы");


        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = @"SELECT a.AchievementId, a.Title, a.Level, a.EventDate, a.Result,
                        COUNT(d.DocId) AS DocCount
                 FROM Achievements a
                 LEFT JOIN AchievementDocs d ON a.AchievementId = d.AchievementId
                 WHERE a.ProfileId = @ProfileId
                 GROUP BY a.AchievementId, a.Title, a.Level, a.EventDate, a.Result";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProfileId", profileId);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int rowIndex = dataGridViewAchievements.Rows.Add(
                        reader["Title"].ToString(),
                        reader["Level"].ToString(),
                        Convert.ToDateTime(reader["EventDate"]).ToShortDateString(),
                        reader["Result"].ToString(),
                        $"📎 {reader["DocCount"]}" // Пятая колонка — документы
                    );
                    // Сохраняем AchievementId в Tag строки для дальнейшего доступа
                    dataGridViewAchievements.Rows[rowIndex].Tag = (int)reader["AchievementId"];
                }
            }

        }
    }
    private void dataGridViewAchievements_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Если кликнули по колонке "Документы" (предположим индекс 4)
        if (e.ColumnIndex == 4 && e.RowIndex >= 0)
        {
            int achievementId = (int)dataGridViewAchievements.Rows[e.RowIndex].Tag;
            ShowAchievementDocs(achievementId);
        }
    }
    private void ShowAchievementDocs(int achievementId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT FileName, FilePath FROM AchievementDocs WHERE AchievementId = @AchievementId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AchievementId", achievementId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string filePath = reader["FilePath"].ToString();
                    string fileName = reader["FileName"].ToString();

                    if (System.IO.File.Exists(filePath))
                    {
                        string extension = System.IO.Path.GetExtension(filePath).ToLower();

                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp")
                        {
                            // Открываем в окне предпросмотра
                            ShowImage(filePath, fileName);
                        }
                        else
                        {
                            // Просто открываем через системное средство
                            System.Diagnostics.Process.Start(filePath);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Файл не найден:\n{filePath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
    private void ShowImage(string filePath, string title)
    {
        Form imageForm = new Form();
        imageForm.Text = title;
        imageForm.Size = new System.Drawing.Size(800, 600);

        PictureBox pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.Image = System.Drawing.Image.FromFile(filePath);

        imageForm.Controls.Add(pictureBox);
        imageForm.ShowDialog();
    }



    private void btnAddAchievement_Click(object sender, EventArgs e)
    {
        AchievementEditForm editForm = new AchievementEditForm(profileId);
        if (editForm.ShowDialog() == DialogResult.OK)
        {
            LoadAchievements();
        }
    }
}
