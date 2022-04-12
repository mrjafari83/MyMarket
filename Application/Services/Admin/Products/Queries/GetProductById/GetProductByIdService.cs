using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.Products.Queries.GetProductById
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IDataBaseContext db;
        public GetProductByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetProductByIdDto> Execute(int id)
        {
            GetProductByIdDto product = new GetProductByIdDto();

            product = db.Products.Include(p => p.Features).Include(p => p.Keywords)
                .Include(p => p.Colors).ThenInclude(c=> c.Color).Include(p => p.Sizes).Where(p => p.Id == id).Select(p => new GetProductByIdDto 
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand  = p.Brand,
                    ShortDescription = p.ShortDescription,
                    Description = p.Description,
                    Inventory = p.Inventory,
                    Price = p.Price,
                    CategoryId =  p.Category.Id,
                    CategoryName = p. Category.Name,
                    CreateDate = p.CreateDate.ToShamsi(),
                    VisitNumber = p.VisitNumber,
                    Keywords = p.Keywords.Select(k=> new KeywordViewModel { KeywordValue = k.Value}).ToList(),
                    Sizes = p.Sizes.Select(s=> new SizeViewModel { SizeValue = s.Size.Value}).ToList(),
                    Colors = p.Colors.Select(c=> new ColorViewModel { Name = c.Color.Name}).ToList(),
                    Features = p.Features.Select(f=> new FeatureViewModel { Display = f.Display , FeatureValue = f.Value}).ToList()
                }).First();

            if (product != null)
                return new ResultDto<GetProductByIdDto>
                {
                    Data = product,
                    IsSuccess = true
                };
            else
                return new ResultDto<GetProductByIdDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
