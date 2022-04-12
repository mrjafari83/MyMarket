using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.BlogPage.Queries.GetAllBlogPages;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Common;

namespace Application.FacadPatterns.Common
{
    public class CommonBlogPageFacad : ICommonBlogPageFacad
    {
        private readonly IDataBaseContext db;
        public CommonBlogPageFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllBlogPagesService _getAllBlogPagesService;
        public IGetAllBlogPagesService GetAllBlogPages
        {
            get
            {
                return _getAllBlogPagesService ?? new GetAllBlogPagesService(db);
            }
        }
    }
}
