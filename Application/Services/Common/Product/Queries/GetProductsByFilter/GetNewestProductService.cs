using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Product.Queries.GetProductsByFilter
{
    public class GetNewestProductService : IGetProductsByFilterService
    {
        private readonly IDataBaseContext db;
        public GetNewestProductService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetProductByFilterDto> Execute(int pageNumber, int pageSize, int categoryId = 0)
        {
            int totalRows;
            var products = db.Products.OrderByDescending(p => p.CreateDate).Include(p => p.Images).AsQueryable();

            if (categoryId != 0)
                products = products.Where(p => p.CategoryId == categoryId).AsQueryable();

            var finallyProducts = products.Select(p => new GetProductByFilterDto
            {
                Id = p.Id,
                Name = p.Name,
                ShortDescription = p.ShortDescription,
                Image = p.Images.FirstOrDefault().Src
            }).ToPaged(out totalRows, pageNumber, pageSize).ToList();

            if (products != null)
                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = new ResultGetProductByFilterDto
                    {
                        Products = finallyProducts,
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
