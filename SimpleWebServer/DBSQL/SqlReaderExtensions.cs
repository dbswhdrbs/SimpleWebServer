using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.DBSQL
{
    public static class SqlReaderExtensions
    {
        public static T GetFieldValue<T>(this SqlDataReader reader, string columnName)
        {
            return reader.GetFieldValue<T>(reader.GetOrdinal(columnName));
        }
    }
}
