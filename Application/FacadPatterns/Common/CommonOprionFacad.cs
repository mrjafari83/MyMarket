using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Common.Option.Queries.GetAllSliders;
using Application.Services.Common.Option.Commands.CreateBrowser;

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

        private CreateBrowserService _createBrowserService;
        public ICreateBrowserService CreateBrowser
        {
            get
            {
                return _createBrowserService ?? new CreateBrowserService(db);
            }
        }
    }
}
