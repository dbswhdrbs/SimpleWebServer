using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.DBSQL
{
    public class SqlEx
    {
        public delegate void QueryExecCallback(SqlDataReader dataReader);

        /// <summary>
        /// DB 접속을 위한 접속 정보
        /// </summary>
        private static string _connectionString = string.Empty;

        private static string connectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = string.Format("Data Source={0};Initial Catalog={1};user id={2};Password={3}",
                        Properties.Settings.Default.DATA_SOURCE,
                        Properties.Settings.Default.CATALOG,
                        Properties.Settings.Default.ID,
                        Properties.Settings.Default.PASSWORD);
                }

                return _connectionString;
            }
        }

        public void ExecuteQuery(QueryExecCallback queryExecCallback, string queryText, CommandType type = CommandType.Text)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = type;
                        command.CommandText = queryText;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (queryExecCallback != null)
                            {
                                queryExecCallback(reader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
