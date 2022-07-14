using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.BlogPages.Commands.DeleteBlogPage
{
    public interface IDeleteBlogPageService
    {
        Task<ResultDto> Execute(int id);
    }
}
