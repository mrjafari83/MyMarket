using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Product.Queries.GetProductById
{
    public interface IGetProductByIdService
    {
        Task<ResultDto<GetProductByIdDto>> Execute(int id);
    }
}
