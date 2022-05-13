using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.NewsBulletin.Commands.AddEmail;
using Application.Services.Admin.NewsBulletin.Commands.SendNews;
using Application.Services.Admin.NewsBulletin.Queries.GetAllEmails;
using Application.Services.Admin.NewsBulletin.Queries.GetAllNews;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface INewsBulletinFacad
    {
        IAddEmailService AddEmail { get; }
        ISendNewsService SendNews { get; }
        IGetAllEmailsService GetAllEmails { get; }
        IGetNewsService GetNews { get; }
    }
}
