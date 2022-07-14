using System;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.Enums;
using Application.Common.ViewModels.SearchViewModels;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public interface IGetAllBlogPagesService
    {
        Task<ResultDto<GetAllBlogPagesResult>> Execute(BlogPageSearchViewModel searchModel
            , int pageNumber = 1, int pageSize = 10);
    }
}
