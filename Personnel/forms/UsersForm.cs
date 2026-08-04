using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using PersonnelApp.Helpers;

namespace PersonnelApp.Forms
{
    public partial class UsersForm : Form
    {
        private string connectionString = DbConnectionHelper.GetConnectionString();

        public UsersForm()
        {
            InitializeComponent();
            LoadUsers();
            LoadRoles();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        U.UserId,
                        U.Login,
                        R.RoleName,
                        U.IsActive,
                        U.CreatedAt
                    FROM Users U
                    JOIN Roles R ON U.RoleId = R.RoleId
                    ORDER BY U.UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvUsers.DataSource = table;
            }
        }

        private void LoadRoles()
        {
            cmbRoles.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT RoleId, RoleName FROM Roles ORDER BY RoleName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbRoles.Items.Add(new ComboBoxItem
                        {
                            Text = reader["RoleName"].ToString(),
                            Value = reader["RoleId"]
                        });
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtPassword.Text == "" || cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            var roleId = (cmbRoles.SelectedItem as ComboBoxItem).Value;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Users (Login, PasswordHash, RoleId)
                               VALUES (@login, @hash, @role)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                    cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = ComputeHash(txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", roleId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            txtLogin.Clear();
            txtPassword.Clear();
            cmbRoles.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);

            if (MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Users WHERE UserId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadUsers();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private static byte[] ComputeHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString() => Text;
    }
}
