using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;
using Common.ViewModels.SearchViewModels;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public interface IGetAllBlogPagesService
    {
        Task<ResultDto<GetAllBlogPagesResult>> Execute(BlogPageSearchViewModel searchModel
            , int pageNumber = 1, int pageSize = 10);
    }
}
