using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.Messages.Commands.AddCriticsmMessage;

namespace Application.Interfaces.FacadPatterns.Client
{
    public interface IClientMessageFacad
    {
        IAddCriticismMessageService AddCriticismMessage { get; }
    }
}
