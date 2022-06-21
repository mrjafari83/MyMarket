using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.BlogPages.Commands.CreateBlogPage;
using Application.Services.Admin.BlogPages.Commands.EditBlogPage;
using Application.Services.Admin.BlogPages.Commands.DeleteBlogPage;
using Application.Services.Admin.BlogPages.Queries.GetBlogPageById;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.Context;
using AutoMapper;

namespace Application.FacadPatterns.Admin
{
    public class BlogPageFacad : IBlogPageFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public BlogPageFacad(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetBlogPageByIdService _getBlogPageByIdService;
        public GetBlogPageByIdService GetBlogPageByIdService
        {
            get
            {
                return _getBlogPageByIdService == null ? new GetBlogPageByIdService(db,_mapper) : _getBlogPageByIdService;
            }
        }

        private CreateBlogPageService _createBlogPageService;
        public CreateBlogPageService CreateBlogPageService
        {
            get
            {
                return _createBlogPageService == null ? new CreateBlogPageService(db,_mapper) : _createBlogPageService;
            }
        }

        private EditBlogPageService _editBlogPageService;
        public EditBlogPageService EditBlogPageService
        {
            get
            {
                return _editBlogPageService == null ? new EditBlogPageService(db) : _editBlogPageService;
            }
        }

        private DeleteBlogPageService _deleteBlogPageService;
        public DeleteBlogPageService DeleteBlogPageService
        {
            get
            {
                return _deleteBlogPageService == null ? new DeleteBlogPageService(db) : _deleteBlogPageService;
            }
        }
    }
}
