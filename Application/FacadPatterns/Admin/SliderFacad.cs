using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Slider.Commands.CreateSlider;
using Application.Services.Admin.Slider.Commands.ReplaceSlider;
using Application.Services.Admin.Slider.Commands.DeleteSlider;

namespace Application.FacadPatterns.Admin
{
    public class SliderFacad : ISliderFacad
    {
        private readonly IDataBaseContext db;
        public SliderFacad(IDataBaseContext context)
        {
            db = context;
        }

        private CreateSliderService _createSliderService;
        public ICreateSliderService CreateSlider 
        {
            get
            {
                return _createSliderService ?? new CreateSliderService(db);
            }
        }

        private ReplaceSliderService _replaceSliderService;
        public IReplaceSliderService ReplaceSlider
        {
            get
            {
                return _replaceSliderService ?? new ReplaceSliderService(db);
            }
        }

        private DeleteSliderService _deleteSliderService;
        public IDeleteSliderService DeleteSlider
        {
            get
            {
                return _deleteSliderService ?? new DeleteSliderService(db);
            }
        }
    }
}
