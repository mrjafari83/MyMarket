using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.NewsBulletin.Commands.SendNews
{
    public interface ISendNewsService
    {
        ResultDto Execute(string subject, string text);
    }
}
