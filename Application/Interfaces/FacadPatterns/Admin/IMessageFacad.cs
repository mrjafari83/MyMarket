using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Message.Queries.GetAllCriticismMessages;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IMessageFacad
    {
        IGetAllCriticsmMessagesService GetAllCriticsmMessages { get; }
    }
}
