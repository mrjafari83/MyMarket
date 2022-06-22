using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Products.Queries.GetProductById
{
    public interface IGetProductByIdService
    {
        Task<ResultDto<GetProductByIdDto>> Execute(int id);
    }
}
