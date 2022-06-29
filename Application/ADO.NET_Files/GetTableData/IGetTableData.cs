using Common.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADO.NET_Files.GetTableData
{
    public interface IGetTableData
    {
        void Execute(string tableName);
    }

    public class GetTableData : IGetTableData
    {
        public void Execute(string tableName)
        {
            var data = new DataTable();
            using (var connection = new SqlConnection(ConnectionStrings.DefaultConnectionString))
            {
                string query = $@"select * From {tableName}";
                var command = new SqlCommand(query,connection);

                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(data);
                var i = data.Rows;
                connection.Close();
            }
        }
    }
}
