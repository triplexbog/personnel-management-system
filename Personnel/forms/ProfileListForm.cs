using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PersonnelApp.Helpers;

namespace PersonnelApp.Forms
{
    public partial class ProfileListForm : Form
    {
        private string connectionString = DbConnectionHelper.GetConnectionString();

        public ProfileListForm()
        {
            InitializeComponent();
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Profiles"; // Замените на ваш запрос для получения данных профилей
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                profilesGridView.DataSource = dataTable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProfileEditForm editForm = new ProfileEditForm();
            editForm.ShowDialog();
            LoadProfiles(); // Перезагружаем данные после добавления
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (profilesGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите профиль для редактирования.");
                return;
            }

            // Предполагаем, что в гриде есть столбец "ProfileId"
            int profileId = Convert.ToInt32(profilesGridView.CurrentRow.Cells["ProfileId"].Value);

            // Передаём id в конструктор формы редактирования
            using (var editForm = new ProfileEditForm(profileId))
            {
                editForm.ShowDialog();
            }

            LoadProfiles(); // обновляем список после закрытия формы
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (profilesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите профиль для удаления.");
                return;
            }

            int profileId = Convert.ToInt32(profilesGridView.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот профиль?", "Удаление профиля", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Profiles WHERE ProfileId = @ProfileId"; // Замените на ваш запрос
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProfileId", profileId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                LoadProfiles(); // Перезагружаем данные после удаления
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                LoadProfiles();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Profiles WHERE Name LIKE @Filter OR Department LIKE @Filter";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Filter", "%" + filter + "%");
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                profilesGridView.DataSource = dataTable;
            }
        }
    }
}
