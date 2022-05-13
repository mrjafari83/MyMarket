using System.Collections.Generic;
using Common.ViewModels;

namespace Application.Services.Admin.Message.Queries.GetAllCriticismMessages
{
    public class GetAllCriticsmMessagesDto
    {
        public int TotalRows { get; set; }
        public List<CriticismMessageViewModel> Messages { get; set; }
    }
}
