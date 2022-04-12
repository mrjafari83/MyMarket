using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public interface ICreateProductService
    {
        ResultDto Execute(CreateProductServiceDto entry);
    }
}
