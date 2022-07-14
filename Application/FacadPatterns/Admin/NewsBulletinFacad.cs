using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.NewsBulletin.Commands.AddEmail;
using Application.Services.Admin.NewsBulletin.Commands.SendNews;
using Application.Services.Admin.NewsBulletin.Queries.GetAllEmails;
using Application.Services.Admin.NewsBulletin.Queries.GetAllNews;
using Application.Services.Admin.NewsBulletin.Queries.GetNewsById;

namespace Application.FacadPatterns.Admin
{
    public class NewsBulletinFacad : INewsBulletinFacad
    {
        private readonly IDataBaseContext db;
        public NewsBulletinFacad(IDataBaseContext context)
        {
            db = context;
        }

        private AddEmailService _addEmailService;
        public IAddEmailService AddEmail 
        {
            get
            {
                return _addEmailService ?? new AddEmailService(db);
            }
        }

        private SendNewsService _sendNewsService;
        public ISendNewsService SendNews
        {
            get
            {
                return _sendNewsService ?? new SendNewsService(db);
            }
        }

        private GetAllEmailsService _getAllEmailsService;
        public IGetAllEmailsService GetAllEmails
        {
            get
            {
                return _getAllEmailsService ?? new GetAllEmailsService(db);
            }
        }

        private GetNewsService _getNewsService;
        public IGetNewsService GetNews
        {
            get
            {
                return _getNewsService ?? new GetNewsService(db);
            }
        }

        private GetNewsByIdService _getNewsByIdService;
        public IGetNewsByIdService GetNewsById
        {
            get
            {
                return _getNewsByIdService ?? new GetNewsByIdService(db);
            }
        }
    }
}
