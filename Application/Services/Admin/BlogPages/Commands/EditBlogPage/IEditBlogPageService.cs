using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.BlogPages.Commands.EditBlogPage
{
    public interface IEditBlogPageService
    {
        Task<ResultDto> Execute(EditBlogPageDto entry);
    }
}
