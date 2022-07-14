using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.ViewModels;

namespace Application.Services.Client.Messages.Commands.AddCriticsmMessage
{
    public interface IAddCriticismMessageService
    {
        ResultDto Execute(CriticismMessageViewModel message);
    }
}
