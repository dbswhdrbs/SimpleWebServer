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

        public static int ExecuteQuery(string procedureName, List<SqlParameter> parameters)
        {
            int resultCode = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters.ToArray());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultCode = reader.GetInt32(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return resultCode;
        }
    }
}
