using Common.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.EndPoint.Utilities
{
    public interface IGetProductDetailsExcel
    {
        Task<string> GetProductDetails(List<int> Ids);
    }
}
