using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.BlogPages.Commands.EditBlogPage
{
    public interface IEditBlogPageService
    {
        ResultDto Execute(EditBlogPageDto entry);
    }
}
