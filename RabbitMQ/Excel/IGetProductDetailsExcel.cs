using Common.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitMQ.Excel
{
    public interface IGetProductDetailsExcel
    {
        string GetProductDetails<Type>(List<Type> source, string address,string sheetName);
    }
}
