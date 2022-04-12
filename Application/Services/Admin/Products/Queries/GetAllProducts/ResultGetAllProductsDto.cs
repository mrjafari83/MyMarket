using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class ResultGetAllProductsDto
    {
        public int TotalRows { get; set; }
        public List<GetAllProductDto> Products { get; set; }
    }
}
