using System.Linq;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Admin.Products.Queries.GetBestSellingProducts
{
    public class GetBestSellingProductsService : IGetBestSellingProductsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetBestSellingProductsService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultGetBestSellingProductDto>> Execute(int pageNumber, int pageSize)
        {
            int totalRows = 0;

            var products = _mapper.ProjectTo<GetBestSellingDto>
                (db.ProductInventories.Include(p => p.Product).ThenInclude(p => p.Images)
                .Include(p => p.ProductInCarts))
                .OrderByDescending(p => p.SellingCount).ToPaged(out totalRows, pageNumber, pageSize);

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
                    Products = await products.ToListAsync(),
                    TotalRows = totalRows
                },
                IsSuccess = true
            };
        }
    }
}
