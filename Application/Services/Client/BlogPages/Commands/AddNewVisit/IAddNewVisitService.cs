using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Client.BlogPages.Commands.AddNewVisit
{
    public interface IAddNewVisitService
    {
        ResultDto Execute(int id, string browserCode);
    }

    public class AddNewVisitService : IAddNewVisitService
    {
        private readonly IDataBaseContext db;
        public AddNewVisitService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id, string browserCode)
        {
            var blogPage = db.BlogPages.Find(id);
            blogPage.Visits.Add(new Domain.Entities.BlogPages.BlogPagesVisit
            {
                Browser = db.Browsers.Where(b => b.BrowserCode == browserCode).FirstOrDefault(),
                BlogPage = blogPage
            });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
