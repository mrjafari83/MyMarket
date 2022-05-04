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

        public ResultDto Execute(string url , string imageSrc)
        {
            db.Sliders.Add(new Domain.Entities.Option.Slider
            {
                Url = url,
                ImageSrc = imageSrc
            });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
