using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.Products.Queries.GetBestSellingProducts
{
    public class GetBestSellingProductsService : IGetBestSellingProductsService
    {
        private readonly IDataBaseContext db;
        public GetBestSellingProductsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetBestSellingProductDto> Execute(int pageNumber, int pageSize)
        {
            int totalRows = 0;
            var products = db.Products.Include(p => p.ProductInCarts).Include(p => p.Images).Select(p => new GetBestSellingDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageSrc = p.Images.FirstOrDefault().Src,
                Inventory = p.Inventory,
                Price = p.Price,
                SellingCount = p.ProductInCarts.Sum(pc=> pc.Count),
            }).OrderByDescending(p=> p.SellingCount).ToPaged(out totalRows , pageNumber , pageSize).ToList();

            if (products == null)
                return new ResultDto<ResultGetBestSellingProductDto>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<ResultGetBestSellingProductDto>
            {
                Data = new ResultGetBestSellingProductDto
                {
                    Products = products,
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }
}
