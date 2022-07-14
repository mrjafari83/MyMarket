using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using AutoMapper;
using Application.Common.Dto;
using Application.Common.Enums;
using Application.Common.Utilities;
using Application.Persistance.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Application.Common.ViewModels;
using Application.Services.Admin.Options.Queries.GetEntitiesByFilter;
using Microsoft.Extensions.Logging;
using Application.Common.ViewModels.SearchViewModels;
using Application.Services.Admin.User.Queries.GetUsersByFilter;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly IMapper _mapper;
        private readonly IGetEntitiesByFilterService _getEntitiesByfilterService;
        public GetAllProductsService(IDataBaseContext context, IMapper mapper
            , SaveLogInFile saveLogInFile, IGetUserByFilter getUserBySearch)
        {
            _mapper = mapper;
            _getEntitiesByfilterService = new GetEntitiesByFilterService(context, saveLogInFile, getUserBySearch);
        }

        public async Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber, int pageSize, ProducsSearchViewModel model)
        {
            int totalRows = 0;

            var products = _getEntitiesByfilterService.GetProductsByFilter(model);

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
