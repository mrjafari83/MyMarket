using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Application.Services.Admin.Categories.Commands.DeleteCategory;
using Application.Services.Admin.Categories.Queries.GetCategoryById;

namespace Application.FacadPatterns.Admin
{
    public class BlogPageCategoryFacad : IBlogPageCategoryFacad
    {
        private readonly IDataBaseContext db;
        public BlogPageCategoryFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetBlogPagetCategoryByIdService _getBlogPagetCategoryByIdService;
        public IGetCategoryByIdService GetById
        {
            get
            {
                return _getBlogPagetCategoryByIdService == null
                    ? new GetBlogPagetCategoryByIdService(db)
                    : _getBlogPagetCategoryByIdService;
            }
        }

        private CreateBlogPageCategoryService _createBlogPageCategoryService;
        public ICreateCategoryService Create
        {
            get
            {
                return _createBlogPageCategoryService == null
                    ? new CreateBlogPageCategoryService(db)
                    : _createBlogPageCategoryService;
            }
        }

        private EditBlogPageCategoryService _editBlogPageCategoryService;
        public IEditCategoryService Edit
        {
            get
            {
                return _editBlogPageCategoryService == null
                    ? new EditBlogPageCategoryService(db)
                    : _editBlogPageCategoryService;
            }
        }

        private DeleteBlogPageCategoryService _deleteBlogPageCategoryService;
        public IDeleteCategoryService Delete
        {
            get
            {
                return _deleteBlogPageCategoryService == null
                    ? new DeleteBlogPageCategoryService(db)
                    : _deleteBlogPageCategoryService;
            }
        }
    }
}
