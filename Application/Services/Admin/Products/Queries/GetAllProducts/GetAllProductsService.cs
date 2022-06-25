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

        public async Task<ResultDto<ResultGetAllProductsDto>> Execute(int pageNumber, int pageSize, int startPrice = 0, int endPrice = 0, string searchKey = ""
            ,Enums.PageFilterCategory searchBy = Enums.PageFilterCategory.Name, Enums.PagesFilter orderBy = Enums.PagesFilter.Newest)
        {
            int totalRows;
            var products = db.Products.Include(p => p.Category).Include(p => p.Visits).AsQueryable();

            if(!string.IsNullOrEmpty(searchKey))
                switch (searchBy)
                {
                    case Enums.PageFilterCategory.Name:
                        {
                            products = products.Where(p => p.Name.Contains(searchKey)).AsQueryable();
                            break;
                        }
                    case Enums.PageFilterCategory.Brand:
                        {
                            products = products.Where(p => p.Brand.Contains(searchKey)).AsQueryable();
                            break;
                        }
                    case Enums.PageFilterCategory.CategoryName:
                        {
                            products = products.Where(p => p.Category.Name.Contains(searchKey)).AsQueryable();
                            break;
                        }
                }

            switch (orderBy)
            {
                case Enums.PagesFilter.LessViewed:
                    {
                        products = products.OrderBy(p=> p.Visits.Count()).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.MostViewed:
                    {
                        products = products.OrderByDescending(p => p.Visits.Count()).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.Newest:
                    {
                        products = products.OrderByDescending(p => p.CreateDate).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.Oldest:
                    {
                        products = products.OrderBy(p => p.CreateDate).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.MostSelled:
                    {
                        products = products.OrderByDescending(p => p.ProductInCarts.Where(p => !p.IsShow)
                        .Sum(c=> c.Count*c.ProductInventoryAndPrice.Price)).AsQueryable();
                        break;
                    }
                case Enums.PagesFilter.LessSelled:
                    {
                        products = products.OrderBy(p => p.ProductInCarts.Where(p => !p.IsShow)
                        .Sum(c => c.Count * c.ProductInventoryAndPrice.Price)).AsQueryable();
                        break;
                    }
            }

            if (startPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price > startPrice).Count() != 0);

            if (endPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price < endPrice).Count() != 0);

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
