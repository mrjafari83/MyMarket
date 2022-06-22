using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.Utilities;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetAllProductsService(IDataBaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber, int pageSize)
        {
            int totalRows;
            var products = _mapper.ProjectTo<GetAllProductDto>(db.Products.Include(p => p.Category).Include(p => p.Visits))
                .ToPaged(out totalRows, pageNumber, pageSize);

            if (products != null)
                return new ResultDto<ResultGetAllProductsDto>
                {
                    Data = new ResultGetAllProductsDto
                    {
                        Products = await products.ToListAsync(),
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
