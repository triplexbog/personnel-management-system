// Forms/LoginForm.cs
using System;
using System.Data.SqlClient; // ← стандартный SQL-клиент
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Personnel;
using PersonnelApp.Helpers;

namespace PersonnelApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] hash = ComputeHash(password);

            using (SqlConnection conn = new SqlConnection(DbConnectionHelper.GetConnectionString()))
            {
                conn.Open();
                string sql = @"SELECT UserId
                               FROM Users
                               WHERE Login = @login
                                 AND PasswordHash = @hash
                                 AND IsActive = 1";
               

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@hash", hash);

                    object userId = cmd.ExecuteScalar();

                    if (userId != null)
                    {
                        Program.CurrentUserId = Convert.ToInt32(userId);
                        MessageBox.Show("Успешный вход.", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private byte[] ComputeHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
    }
}
