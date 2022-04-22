using System.Collections.Generic;

namespace Application.Services.Admin.Products.Queries.GetBestSellingProducts
{
    public class ResultGetBestSellingProductDto
    {
        public List<GetBestSellingDto> Products { get; set; }
        public int TotalRows { get; set; }
    }
}
