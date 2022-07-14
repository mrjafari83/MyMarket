using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistance.Context;
using Common.Dto;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Product.Queries.GetProductsByFilter
{
    public class GetMostViewedProductService : IGetProductsByFilterService
    {
        private readonly IDataBaseContext db;
        public GetMostViewedProductService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<ResultGetProductByFilterDto>> Execute(int pageNumber , int pageSize, int categoryId = 0)
        {
            int totalRows;
            var products = db.Products.OrderByDescending(p => p.Visits.Count()).Include(p=> p.Images).Select(p => new GetProductByFilterDto
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Images.FirstOrDefault().Src,
                ShortDescription = p.ShortDescription,
            }).ToPaged(out totalRows , pageNumber , pageSize);

            if (products != null)
                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = new ResultGetProductByFilterDto
                    {
                        Products = await products.AsNoTracking().ToListAsync(),
                        TotalRows = totalRows
                    },
                    IsSuccess = true
                };
            else
                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
