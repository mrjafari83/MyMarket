using Common.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADO.NET_Files.GetTableInfo
{
    public interface IGetTableInfo
    {
        (List<ColumnsInfoDto> columns, int columnsCount) Execute(string tableName);
    }

    public class GetTableInfo : IGetTableInfo
    {
        public (List<ColumnsInfoDto> columns, int columnsCount) Execute(string tableName)
        {
            var connectionString = ConnectionStrings.DefaultConnectionString;
            var query = @$"select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{tableName}'";
            List<ColumnsInfoDto> columns = new List<ColumnsInfoDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        columns.Add(new ColumnsInfoDto()
                        {
                            ColumnName = reader["COLUMN_NAME"].ToString(),
                            ColumnType = reader["DATA_TYPE"].ToString(),
                        });
                    }
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }

            return (columns, columns.Count());
        }
    }

    public class ColumnsInfoDto
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
    }
}
