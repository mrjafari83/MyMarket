using System.Collections.Generic;
using Application.Common.Dto;

namespace Application.Services.Common.Product.Queries.GetProductsBySearch
{
    public class ResultGetProductsBySearchDto
    {
        public List<GetProductByFilterDto> Products { get; set; }
        public int TotalRows { get; set; }
    }
}
