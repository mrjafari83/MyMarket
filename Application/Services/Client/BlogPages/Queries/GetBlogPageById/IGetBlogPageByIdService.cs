using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.BlogPages.Queries.GetBlogPageById
{
    public interface IGetBlogPageByIdService
    {
        ResultDto<GetBlogPageByIdDto> Execute(int id);
    }
}
