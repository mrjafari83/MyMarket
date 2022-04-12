using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly IDataBaseContext db;
        public GetAllProductsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetAllProductsDto> Execute(int pageNumber , int pageSize)
        {
            int totalRows;
            List<GetAllProductDto> products = new List<GetAllProductDto>();

            products = db.Products.Select(p => new GetAllProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Inventory = p.Inventory,
                VisitNumber = p.VisitNumber,
                CategoryName = p.Category.Name,
                CategoryId = p.CategoryId,
            }).ToPaged(out totalRows , pageNumber , pageSize).ToList();

            if (products != null)
                return new ResultDto<ResultGetAllProductsDto>
                {
                    Data = new ResultGetAllProductsDto 
                    {
                        Products = products,
                        TotalRows = totalRows
                    },
                    IsSuccess = true
                };
            else
                return new ResultDto<ResultGetAllProductsDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
