using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.ViewModels.SearchViewModels;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public interface IGetAllCriticsmMessagesService
    {
        Task<ResultDto<GetAllCriticsmMessagesDto>> Execute(MessageSearchViewModel searchModel , int pageNumber = 1, int pageSize = 10);
    }
}
