using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Option.Queries.GetAllSliders
{
    public class GetAllSliderService : IGetAllSliderService
    {
        private readonly IDataBaseContext db;
        public GetAllSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllSlidersDto>> Execute()
        {
            var sliders = db.Sliders.Include(s => s.Product.Images).Select(s => new GetAllSlidersDto
            {
                SliderId = s.Id,
                ProductId = s.Product.Id == null ? 0 : s.Product.Id,
                ProductName = s.Product.Name ?? "",
                 ProductPrice = s.Product.Price == null ? 0 : s.Product.Price,
                ProductInventory = s.Product.Inventory == null ? 0 : s.Product.Inventory,
                ProductImage = s.Product.Images.FirstOrDefault().Src ?? ""
            }).ToList();

            return new ResultDto<List<GetAllSlidersDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
