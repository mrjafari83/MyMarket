using Application.ADO.NET_Files.GetTableInfo;
using Common.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADO.NET_Files.SearchToAddNewColumn
{
    public interface ISearchToAddNewColumn
    {
        void Execute(string tableName, string columnName, Type columnType, bool notNull);
    }

    public class SearchToAddNewColumn : ISearchToAddNewColumn
    {
        public void Execute(string tableName, string columnName, Type columnType, bool notNull)
        {
            string dataType = "";

            if (columnType == typeof(string))
                dataType = "nvarchar(MAX)";
            if (columnType == typeof(int))
                dataType = "int";
            if (columnType == typeof(DateTime))
                dataType = "datetime";

            var connectionString = ConnectionStrings.DefaultConnectionString;
            IGetTableInfo getTableInfo = new Application.ADO.NET_Files.GetTableInfo.GetTableInfo();
            var columns = getTableInfo.Execute(tableName).columns;

            if (columns != null)
                if (!columns.Any(c => c.ColumnName == columnName))
                {
                    var query = $@"alter table {tableName} add {columnName} {dataType}";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        command.Clone();
                    }
                }
        }
    }
}
