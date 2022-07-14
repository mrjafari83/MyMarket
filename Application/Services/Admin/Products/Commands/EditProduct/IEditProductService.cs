using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Products.Commands.EditProduct
{
    public interface IEditProductService
    {
        Task<ResultDto> Execute(EditProductDto entry);
    }
}
