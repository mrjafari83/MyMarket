using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public interface IGetAllBlogPagesService
    {
        Task<ResultDto<GetAllBlogPagesResult>> Execute(Enums.PagesFilter filter = Enums.PagesFilter.Newest
            , int pageNumber = 1, int pageSize = 10 , string searchKey = "" , int categoryId = 0);
    }
}
