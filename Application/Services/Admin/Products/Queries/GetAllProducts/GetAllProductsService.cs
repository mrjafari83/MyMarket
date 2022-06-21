using System.Collections.Generic;
using System.Linq;
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

        public ResultDto<ResultGetAllProductsDto> Execute(int pageNumber, int pageSize)
        {
            int totalRows;
            var products = _mapper.Map<List<GetAllProductDto>>(db.Products.Include(p=> p.Category).Include(p=> p.Visits).ToList())
                .ToPaged(out totalRows, pageNumber, pageSize).ToList();

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
