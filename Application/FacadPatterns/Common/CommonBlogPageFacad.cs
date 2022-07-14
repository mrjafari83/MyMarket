using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.BlogPage.Queries.GetAllBlogPages;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Common;
using AutoMapper;

namespace Application.FacadPatterns.Common
{
    public class CommonBlogPageFacad : ICommonBlogPageFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public CommonBlogPageFacad(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetAllBlogPagesService _getAllBlogPagesService;
        public IGetAllBlogPagesService GetAllBlogPages
        {
            get
            {
                return _getAllBlogPagesService ?? new GetAllBlogPagesService(db ,_mapper);
            }
        }
    }
}
