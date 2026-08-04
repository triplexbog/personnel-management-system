using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using PersonnelApp.Helpers;
using System.Drawing;

namespace Personnel.forms
{
    public partial class DocumentViewerForm : Form
    {
        private int documentId;
        private int currentVersion;
        private List<(int VersionNumber, string FilePath)> versions;

        public DocumentViewerForm(int docId)
        {
            InitializeComponent();
            documentId = docId;
            LoadVersions();
            ShowVersion(0);
        }

        private void LoadVersions()
        {
            versions = new List<(int, string)>();
            using (var conn = new SqlConnection(DbConnectionHelper.GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT VersionNumber, FilePath 
                      FROM DocumentVersions
                     WHERE DocumentId = @docId 
                  ORDER BY VersionNumber", conn);
                cmd.Parameters.AddWithValue("@docId", documentId);

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        versions.Add(
                            ((int)reader["VersionNumber"],
                              reader["FilePath"].ToString())
                        );
            }
        }

        private void ShowVersion(int index)
        {
            if (index < 0 || index >= versions.Count)
                return;

            currentVersion = index;
            var (versionNumber, filePath) = versions[index];
            Text = $"Документ – Версия {versionNumber}";

            if (Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                webBrowser1.Navigate(filePath);
                pictureBox1.Visible = false;
                webBrowser1.Visible = true;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(filePath);
                webBrowser1.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
            => ShowVersion(currentVersion + 1);

        private void btnPrevious_Click(object sender, EventArgs e)
            => ShowVersion(currentVersion - 1);
    }
}
