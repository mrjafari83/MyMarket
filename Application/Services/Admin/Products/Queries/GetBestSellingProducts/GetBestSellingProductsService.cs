using System.Linq;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public ResultDto<ResultGetBestSellingProductDto> Execute(int pageNumber, int pageSize)
        {
            int totalRows = 0;

            var products = _mapper.Map<List<GetBestSellingDto>>
                (db.ProductInventories.Include(p => p.Product).ThenInclude(p => p.Images)
                .Include(p => p.ProductInCarts).ToList())
                .OrderByDescending(p => p.SellingCount).ToPaged(out totalRows, pageNumber, pageSize).ToList();

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
