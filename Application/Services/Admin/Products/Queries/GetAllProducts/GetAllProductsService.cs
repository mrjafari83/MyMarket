using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Enums;
using Common.Utilities;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Application.Services.Admin.Common.Queries.GetProductsBySearch;
using Common.ViewModels;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        private readonly GetProductsBySearch _getProductsBySearch;
        public GetAllProductsService(IDataBaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
            _getProductsBySearch = new GetProductsBySearch(context);
        }

        public async Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber, int pageSize, SearchViewModel model)
        {
            int totalRows = 0;

            var products = _getProductsBySearch.GetProducts(model);

            if (products != null)
                return new ResultDto<ResultGetAllProductsDto>
                {
                    Data = new ResultGetAllProductsDto
                    {
                        Products = await _mapper.ProjectTo<GetAllProductDto>(products).ToPaged(out totalRows, pageNumber, pageSize).AsNoTracking().ToListAsync(),
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
