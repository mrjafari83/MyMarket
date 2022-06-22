using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Product.Queries.GetProductsBySearch
{
    public interface IGetProductsBySearchService
    {
        Task<ResultDto<ResultGetProductByFilterDto>> Execute(string searchKey , int pageSize , int pagNumber = 1);
    }
}
