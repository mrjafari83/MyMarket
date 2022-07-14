using System;
using System.Threading.Tasks;
using Persistance.Context;
using Common.Dto;

namespace Application.Services.Admin.Slider.Commands.DeleteSlider
{
    public class DeleteSliderService : IDeleteSliderService
    {
        private readonly IDataBaseContext db;
        public DeleteSliderService(IDataBaseContext context)
        {
            db = context; ;
        }

        public async Task<ResultDto> Execute(int sliderId)
        {
            var slider = await db.Sliders.FindAsync(sliderId);
            slider.IsRemoved = true;
            slider.RemoveTime = DateTime.Now;
            db.Sliders.Update(slider);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
