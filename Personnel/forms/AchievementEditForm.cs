using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Personnel;
using PersonnelApp.Helpers;

public partial class AchievementEditForm : Form
{
    private string connectionString = DbConnectionHelper.GetConnectionString();
    private int profileId;
    private string selectedFilePath = null;

    public AchievementEditForm(int profileId)
    {
        InitializeComponent();
        this.profileId = profileId;

        comboLevel.Items.AddRange(new string[] { "Школьный", "Городской", "Региональный", "Федеральный" });
        comboLevel.SelectedIndex = 0;
        dateEvent.Value = DateTime.Now;
    }

    private void btnAttachDocument_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "Image files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp|PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            selectedFilePath = dialog.FileName;
            if (Path.GetExtension(selectedFilePath).ToLower() != ".pdf")
            {
                picturePreview.ImageLocation = selectedFilePath;
            }
            else
            {
                picturePreview.Image = null;
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        int userId = Program.CurrentUserId; // предполагается наличие текущего пользователя

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string insertQuery = @"
                    INSERT INTO Achievements (ProfileId, Title, Level, EventDate, Result, CreatedBy)
                    OUTPUT INSERTED.AchievementId
                    VALUES (@ProfileId, @Title, @Level, @EventDate, @Result, @CreatedBy)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction);
                cmd.Parameters.AddWithValue("@ProfileId", profileId);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Level", comboLevel.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@EventDate", dateEvent.Value.Date);
                cmd.Parameters.AddWithValue("@Result", txtResult.Text.Trim());
                cmd.Parameters.AddWithValue("@CreatedBy", userId);

                int achievementId = (int)cmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    string fileName = Path.GetFileName(selectedFilePath);
                    string targetPath = Path.Combine("Achievements", $"{achievementId}_{fileName}");
                    Directory.CreateDirectory("Achievements");
                    File.Copy(selectedFilePath, targetPath, true);

                    SqlCommand docCmd = new SqlCommand(@"
                        INSERT INTO AchievementDocs (AchievementId, FileName, FilePath, UploadedBy)
                        VALUES (@AchievementId, @FileName, @FilePath, @UploadedBy)", conn, transaction);

                    docCmd.Parameters.AddWithValue("@AchievementId", achievementId);
                    docCmd.Parameters.AddWithValue("@FileName", fileName);
                    docCmd.Parameters.AddWithValue("@FilePath", targetPath);
                    docCmd.Parameters.AddWithValue("@UploadedBy", userId);
                    docCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Достижение сохранено.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}
