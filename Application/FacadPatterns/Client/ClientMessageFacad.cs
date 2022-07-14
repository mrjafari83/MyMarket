using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Client;
using Application.Services.Client.Messages.Commands.AddCriticsmMessage;

namespace Application.FacadPatterns.Client
{
    public class ClientMessageFacad : IClientMessageFacad
    {
        private readonly IDataBaseContext db;
        public ClientMessageFacad(IDataBaseContext context)
        {
            db = context;
        }

        private AddCriticismMessageService _addCriticismMessageService;
        public IAddCriticismMessageService AddCriticismMessage 
        { 
            get
            {
                return _addCriticismMessageService ?? new AddCriticismMessageService(db);
            }
        }
    }
}
