using System;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;
using Application.Persistance.Entities.Option;

namespace Application.Services.Admin.Slider.Commands.ReplaceSlider
{
    public class ReplaceSliderService : IReplaceSliderService
    {
        private readonly IDataBaseContext db;
        public ReplaceSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int lastSliderId, string url, string imageSrc)
        {
            var lastSlider = await db.Sliders.FindAsync(lastSliderId);
            lastSlider.IsRemoved = true;
            lastSlider.RemoveTime = DateTime.Now;
            db.Sliders.Update(lastSlider);

            await db.Sliders.AddAsync(new Application.Persistance.Entities.Option.Slider 
            {
                Url = url,
                ImageSrc = imageSrc
            });
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
