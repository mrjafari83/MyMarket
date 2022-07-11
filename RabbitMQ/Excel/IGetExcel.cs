using Common.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitMQ.Excel
{
    public interface IGetExcel
    {
        string GetExcelFile<Type>(List<Type> source, string address,string prefixFileName);
    }
}
