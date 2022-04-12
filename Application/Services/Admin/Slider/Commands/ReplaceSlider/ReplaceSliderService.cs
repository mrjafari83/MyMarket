using System;
using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entities.Option;

namespace Application.Services.Admin.Slider.Commands.ReplaceSlider
{
    public class ReplaceSliderService : IReplaceSliderService
    {
        private readonly IDataBaseContext db;
        public ReplaceSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int lastSliderId, int newProdcutId)
        {
            var lastSlider = db.Sliders.Find(lastSliderId);
            lastSlider.IsRemoved = true;
            lastSlider.RemoveTime = DateTime.Now;
            db.Sliders.Update(lastSlider);

            db.Sliders.Add(new Domain.Entities.Option.Slider { Product = db.Products.Find(newProdcutId) });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
