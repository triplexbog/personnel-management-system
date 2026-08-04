namespace PersonnelApp.Forms
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using OfficeOpenXml;
    using PersonnelApp.Helpers;

    public partial class ReportsForm : Form
    {
        private string connectionString = DbConnectionHelper.GetConnectionString();

        public ReportsForm()
        {
            InitializeComponent();
            cmbReportType.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            string sql = string.Empty;

            switch (cmbReportType.SelectedItem.ToString())
            {
                case "Активные сотрудники":
                    sql = @"SELECT p.ProfileId, p.FirstName, p.LastName, p.HireDate, p.TerminationDate
                            FROM Profiles p
                            WHERE p.ProfileType = 2 AND p.IsActive = 1";
                    break;
                case "Достижения за период":
                    sql = @"SELECT a.AchievementId, p.FirstName, p.LastName, a.Title, a.Level, a.EventDate, a.Result
                            FROM Achievements a
                            JOIN Profiles p ON a.ProfileId = p.ProfileId
                            WHERE a.EventDate BETWEEN @from AND @to";
                    break;
                case "Поощрения и взыскания":
                    sql = @"SELECT h.HistoryId, p.FirstName, p.LastName, h.Status, h.ChangedAt
                            FROM ProfileStatusHistory h
                            JOIN Profiles p ON h.ProfileId = p.ProfileId
                            WHERE h.ChangedAt BETWEEN @from AND @to";
                    break;
            }

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (sql.Contains("@from")) cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                if (sql.Contains("@to")) cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date);

                var table = new DataTable();
                adapter.Fill(table);
                dataGridViewReports.DataSource = table;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var table = dataGridViewReports.DataSource as DataTable;
            if (table == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx|CSV File|*.csv";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var filepath = sfd.FileName;
                if (Path.GetExtension(filepath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    using (var pkg = new OfficeOpenXml.ExcelPackage())
                    {
                        var ws = pkg.Workbook.Worksheets.Add("Report");
                        ws.Cells["A1"].LoadFromDataTable(table, true);
                        pkg.SaveAs(new FileInfo(filepath));
                    }
                }
                else
                {
                    using (var writer = new StreamWriter(filepath))
                    {
                        // Header
                        var cols = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
                        writer.WriteLine(string.Join(",", cols));

                        // Rows
                        foreach (DataRow row in table.Rows)
                        {
                            var fields = row.ItemArray.Select(f => f.ToString().Replace(",", " ")).ToArray();
                            writer.WriteLine(string.Join(",", fields));
                        }
                    }
                }

                MessageBox.Show("Данные экспортированы.");
            }
        }

    }
}