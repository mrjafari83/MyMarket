using System;
using Application.Interfaces.Context;
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

        public ResultDto Execute(int sliderId)
        {
            var slider = db.Sliders.Find(sliderId);
            slider.IsRemoved = true;
            slider.RemoveTime = DateTime.Now;
            db.Sliders.Update(slider);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
