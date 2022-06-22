using System.Linq;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Services.Common.Product.Queries.GetProductsBySearch
{
    public class GetProductsBySearchService : IGetProductsBySearchService
    {
        private readonly IDataBaseContext db;
        public GetProductsBySearchService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<ResultGetProductByFilterDto>> Execute(string searchKey, int pageSize, int pagNumber = 1)
        {
            if (searchKey == "")
                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = null,
                    IsSuccess = false
                };
            else
            {
                int totalRows;
                var products = db.Products.Where(p => p.Name.Contains(searchKey))
                    .Select(p => new GetProductByFilterDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ShortDescription = p.ShortDescription,
                        Image = p.Images.First().Src
                    }).ToPaged(out totalRows, pagNumber, pageSize);

                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = new ResultGetProductByFilterDto 
                    { Products = await products.AsNoTracking().ToListAsync(),
                        TotalRows = totalRows
                    },
                    IsSuccess = true
                };
            }
        }
    }
}
