using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.BlogPages.Commands.CreateBlogPage;
using Application.Services.Admin.BlogPages.Commands.EditBlogPage;
using Application.Services.Admin.BlogPages.Commands.DeleteBlogPage;
using Application.Services.Admin.BlogPages.Queries.GetBlogPageById;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IBlogPageFacad
    {
        GetBlogPageByIdService GetBlogPageByIdService { get; }
        CreateBlogPageService CreateBlogPageService { get; }
        EditBlogPageService EditBlogPageService { get; }
        DeleteBlogPageService DeleteBlogPageService { get; }
    }
}
