using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public interface ICreateProductService
    {
        Task<ResultDto<int>> Execute(CreateProductServiceDto entry,List<IFormFile> images = null);
    }
}
