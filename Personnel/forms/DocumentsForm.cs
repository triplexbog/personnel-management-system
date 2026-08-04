using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Personnel;
using Personnel.forms;
using PersonnelApp.Helpers;

namespace PersonnelApp
{
    public partial class DocumentsForm : Form
    {
        private string connectionString = DbConnectionHelper.GetConnectionString();
        int CurrentUser = Program.CurrentUserId;
        public DocumentsForm()
        {
            InitializeComponent();
            LoadFolderTree();
        }

        private void LoadFolderTree()
        {
            treeViewFolders.Nodes.Clear();
            LoadFolders(null, null);
        }

        private void LoadFolders(TreeNode parentNode, int? parentId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT FolderId, Name FROM DocumentFolders WHERE ParentId " +
                    (parentId.HasValue ? "= @parentId" : "IS NULL"), conn);
                if (parentId.HasValue)
                    cmd.Parameters.AddWithValue("@parentId", parentId.Value);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var node = new TreeNode(reader["Name"].ToString())
                    {
                        Tag = (int)reader["FolderId"]
                    };

                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        treeViewFolders.Nodes.Add(node);
                    }

                    // рекурсивно загрузить потомков
                    LoadFolders(node, (int)reader["FolderId"]);
                }
            }
        }


        private void treeViewFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int folderId = (int)e.Node.Tag;
            LoadDocuments(folderId);
        }

        private void LoadDocuments(int folderId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var adapter = new SqlDataAdapter(@"
                    SELECT D.DocumentId, D.Title, D.Description, D.CreatedAt,
                           (SELECT MAX(VersionNumber) FROM DocumentVersions V WHERE V.DocumentId = D.DocumentId) AS LatestVersion
                    FROM Documents D WHERE D.FolderId = @folderId", conn);
                adapter.SelectCommand.Parameters.AddWithValue("@folderId", folderId);

                var table = new DataTable();
                adapter.Fill(table);
                dataGridViewDocuments.DataSource = table;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (treeViewFolders.SelectedNode == null)
                return;

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int folderId = (int)treeViewFolders.SelectedNode.Tag;
                    string fileName = Path.GetFileName(dialog.FileName);
                    string destPath = Path.Combine("Documents", Guid.NewGuid() + Path.GetExtension(fileName));
                    Directory.CreateDirectory("Documents");
                    File.Copy(dialog.FileName, destPath);

                    using (var conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        var trans = conn.BeginTransaction();
                        try
                        {
                            var cmd = new SqlCommand(@"
                                INSERT INTO Documents (FolderId, Title, CreatedBy)
                                OUTPUT INSERTED.DocumentId
                                VALUES (@folderId, @title, @userId)", conn, trans);
                            cmd.Parameters.AddWithValue("@folderId", folderId);
                            cmd.Parameters.AddWithValue("@title", fileName);
                            cmd.Parameters.AddWithValue("@userId", CurrentUser);
                            int docId = (int)cmd.ExecuteScalar();

                            cmd = new SqlCommand(@"
                                INSERT INTO DocumentVersions (DocumentId, FileName, FilePath, VersionNumber, UploadedBy)
                                VALUES (@docId, @fileName, @filePath, 1, @userId)", conn, trans);
                            cmd.Parameters.AddWithValue("@docId", docId);
                            cmd.Parameters.AddWithValue("@fileName", fileName);
                            cmd.Parameters.AddWithValue("@filePath", destPath);
                            cmd.Parameters.AddWithValue("@userId", CurrentUser);
                            cmd.ExecuteNonQuery();

                            trans.Commit();
                            LoadDocuments(folderId);
                        }
                        catch
                        {
                            trans.Rollback();
                            MessageBox.Show("Ошибка при загрузке документа.");
                        }
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocuments.CurrentRow == null)
                return;

            int docId = (int)dataGridViewDocuments.CurrentRow.Cells["DocumentId"].Value;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT TOP 1 FilePath, FileName
                    FROM DocumentVersions
                    WHERE DocumentId = @docId
                    ORDER BY VersionNumber DESC", conn);
                cmd.Parameters.AddWithValue("@docId", docId);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string filePath = reader["FilePath"].ToString();
                    string fileName = reader["FileName"].ToString();

                    using (var sfd = new SaveFileDialog { FileName = fileName })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(filePath, sfd.FileName, true);
                            MessageBox.Show("Файл сохранён.");
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocuments.CurrentRow == null)
                return;

            int docId = (int)dataGridViewDocuments.CurrentRow.Cells["DocumentId"].Value;

            if (MessageBox.Show("Удалить документ?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Documents WHERE DocumentId = @docId", conn);
                    cmd.Parameters.AddWithValue("@docId", docId);
                    cmd.ExecuteNonQuery();
                    LoadDocuments((int)treeViewFolders.SelectedNode.Tag);
                }
            }
        }

        private void dataGridViewDocuments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int docId = (int)dataGridViewDocuments.CurrentRow.Cells["DocumentId"].Value;
            var viewer = new DocumentViewerForm(docId);
            viewer.ShowDialog();
        }
    }
}
