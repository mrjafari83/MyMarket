using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Admin.Options.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsService : IGetAllProductDetailsService
    {
        private readonly IDataBaseContext db;
        public GetAllProductDetailsService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<List<GetAllProductDetailsDto>>> Execute(List<int> Ids)
        {
            var products = db.ProductInventories.Include(p => p.Product).ThenInclude(p => p.Category)
                .Include(p => p.Product).ThenInclude(p => p.Visits).Where(p=> Ids.Contains(p.ProductId)).Select(p => new GetAllProductDetailsDto
                {
                    Name = p.Product.Name,
                    Brand = p.Product.Brand,
                    CategoryName = p.Product.Category.Name,
                    Price = p.Price,
                    SellsCount = p.ProductInCarts.Where(c => !c.IsShow).Sum(c => c.Count),
                    VisitNumber = p.Product.Visits.Count(),
                    Size = p.SizeName,
                    Color = p.ColorName,
                    Inventory = p.Inventory
                }).AsQueryable();

            return new ResultDto<List<GetAllProductDetailsDto>>
            {
                Data = await products.AsNoTracking().ToListAsync(),
            IsSuccess = true
            };
        }
    }
}
