using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Message.Queries.GetAllCriticismMessages;

namespace Application.FacadPatterns.Admin
{
    public class MessageFacad : IMessageFacad
    {
        private readonly IDataBaseContext db;
        public MessageFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllCriticsmMessagesService _getAllCriticsmMessagesService;
        public IGetAllCriticsmMessagesService GetAllCriticsmMessages
        {
            get
            {
                return _getAllCriticsmMessagesService ?? new GetAllCriticsmMessagesService(db);
            }
        }
    }
}
