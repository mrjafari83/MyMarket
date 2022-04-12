using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entities.Option;

namespace Application.Services.Admin.Slider.Commands.CreateSlider
{
    public class CreateSliderService : ICreateSliderService
    {
        private readonly IDataBaseContext db;
        public CreateSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int productId)
        {
            db.Sliders.Add(new Domain.Entities.Option.Slider { Product = db.Products.Find(productId) });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
