using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Products.Queries.GetBestSellingProducts
{
    public interface IGetBestSellingProductsService
    {
        Task<ResultDto<ResultGetBestSellingProductDto>> Execute(int pageNumber, int pageSize);
    }
}
