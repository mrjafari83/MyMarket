using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Products.Commands.EditProduct
{
    public interface IEditProductService
    {
        ResultDto Execute(EditProductDto entry);
    }
}
