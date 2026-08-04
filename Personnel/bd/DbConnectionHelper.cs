using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // ← это стандартная библиотека ADO.NET

// Helpers/DbConnectionHelper.cs
namespace PersonnelApp.Helpers
{
    public static class DbConnectionHelper
    {
        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["PersonnelDb"]
                ?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Строка подключения PersonnelDb не указана в App.config.");
            }

            return connectionString;
        }
    }
}
