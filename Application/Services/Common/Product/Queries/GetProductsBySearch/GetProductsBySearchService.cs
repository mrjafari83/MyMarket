using System.Linq;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;

namespace Application.Services.Common.Product.Queries.GetProductsBySearch
{
    public class GetProductsBySearchService : IGetProductsBySearchService
    {
        private readonly IDataBaseContext db;
        public GetProductsBySearchService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<ResultGetProductByFilterDto> Execute(string searchKey, int pageSize, int pagNumber = 1)
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
                        Price = p.Price,
                        ShortDescription = p.ShortDescription,
                        Image = p.Images.First().Src
                    }).ToPaged(out totalRows, pagNumber, pageSize).ToList();

                return new ResultDto<ResultGetProductByFilterDto>
                {
                    Data = new ResultGetProductByFilterDto { Products = products, TotalRows = totalRows },
                    IsSuccess = true
                };
            }
        }
    }
}
