using System.Collections.Generic;
using Application.Common.ViewModels;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public class GetAllCriticsmMessagesDto
    {
        public int TotalRows { get; set; } = 0;
        public List<CriticismMessageViewModel> Messages { get; set; } = new List<CriticismMessageViewModel>();
    }
}
