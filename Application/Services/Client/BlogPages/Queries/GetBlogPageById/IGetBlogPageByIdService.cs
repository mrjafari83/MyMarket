using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Client.BlogPages.Queries.GetBlogPageById
{
    public interface IGetBlogPageByIdService
    {
        Task<ResultDto<GetBlogPageByIdDto>> Execute(int id);
    }
}
