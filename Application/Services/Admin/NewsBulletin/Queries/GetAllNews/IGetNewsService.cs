using System;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.NewsBulletin.Queries.GetAllNews
{
    public interface IGetNewsService
    {
        ResultDto<GetNewsDto> Execute(int pageNumber = 1, int pageSize = 10);
    }
}
