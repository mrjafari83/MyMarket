using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Persistance.Entities.Option;
using System.Threading.Tasks;

namespace Application.Services.Admin.Slider.Commands.CreateSlider
{
    public class CreateSliderService : ICreateSliderService
    {
        private readonly IDataBaseContext db;
        public CreateSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(string url , string imageSrc)
        {
            await db.Sliders.AddAsync(new Application.Persistance.Entities.Option.Slider
            {
                Url = url,
                ImageSrc = imageSrc
            });
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
