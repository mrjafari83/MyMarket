using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public interface IGetAllCriticsmMessagesService
    {
        ResultDto<GetAllCriticsmMessagesDto> Execute(int pageNumber = 1, int pageSize = 10);
    }
}
