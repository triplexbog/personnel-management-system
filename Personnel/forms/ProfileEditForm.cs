using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using PersonnelApp.Helpers;

public partial class ProfileEditForm : Form
{
    private string connectionString = DbConnectionHelper.GetConnectionString();
    private int? profileId;

    public ProfileEditForm(int? profileId = null)
    {
        InitializeComponent();
        this.profileId = profileId;
        if (profileId != null)
            LoadProfile();
    }

    private void LoadProfile()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Profiles WHERE ProfileId = @ProfileId", conn);
            cmd.Parameters.AddWithValue("@ProfileId", profileId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtLastName.Text = reader["LastName"].ToString();
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtMiddleName.Text = reader["MiddleName"].ToString();
                    dtpBirthDate.Value = reader["BirthDate"] != DBNull.Value ? (DateTime)reader["BirthDate"] : DateTime.Today;
                    cmbGender.Text = reader["Gender"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    chkIsActive.Checked = (bool)reader["IsActive"];
                    cmbProfileType.SelectedIndex = Convert.ToInt32(reader["ProfileType"]) - 1;

                }
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            if (profileId == null)
            {
                cmd.CommandText = @"
                    INSERT INTO Profiles (LastName, FirstName, MiddleName, BirthDate, Gender, Phone, Email, IsActive, ProfileType)
                    VALUES (@LastName, @FirstName, @MiddleName, @BirthDate, @Gender, @Phone, @Email, @IsActive, @ProfileType)";
            }
            else
            {
                cmd.CommandText = @"
                    UPDATE Profiles SET 
                        LastName = @LastName,
                        FirstName = @FirstName,
                        MiddleName = @MiddleName,
                        BirthDate = @BirthDate,
                        Gender = @Gender,
                        Phone = @Phone,
                        Email = @Email,
                        IsActive = @IsActive,
                        ProfileType = @ProfileType
                    WHERE ProfileId = @ProfileId";
                cmd.Parameters.AddWithValue("@ProfileId", profileId);
            }

            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
            cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
            cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
            cmd.Parameters.AddWithValue("@ProfileType", cmbProfileType.SelectedIndex + 1);

            cmd.ExecuteNonQuery();
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
