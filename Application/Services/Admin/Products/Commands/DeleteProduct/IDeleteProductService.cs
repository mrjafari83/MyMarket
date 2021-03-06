using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Products.Commands.DeleteProduct
{
    public interface IDeleteProductService
    {
        Task<ResultDto> Execute(int id);
    }
}
