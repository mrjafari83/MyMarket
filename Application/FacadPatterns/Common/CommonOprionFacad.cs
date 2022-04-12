using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Common.Option.Queries.GetAllSliders;

namespace Application.FacadPatterns.Common
{
    public class CommonOprionFacad : ICommonOptionFacad
    {
        private readonly IDataBaseContext db;
        public CommonOprionFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllSliderService _getAllSliderService;
        public IGetAllSliderService GetAllSlider 
        {
            get
            {
                return _getAllSliderService ?? new GetAllSliderService(db);
            }
        }
    }
}
