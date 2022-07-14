using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Client.BlogPages.Commands.AddNewVisit
{
    public interface IAddNewVisitService
    {
        Task<ResultDto> Execute(int id, string browserCode);
    }

    public class AddNewVisitService : IAddNewVisitService
    {
        private readonly IDataBaseContext db;
        public AddNewVisitService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int id, string browserCode)
        { 
            var blogPage = db.BlogPages.Find(id);
            var browser = db.Browsers.Where(b => b.BrowserCode == browserCode).FirstOrDefault();

            if(!db.BlogPagesVisits.Where(b=> b.BlogPage == blogPage && b.Browser == browser).Any())
            {
                db.BlogPagesVisits.Add(new Application.Persistance.Entities.BlogPages.BlogPagesVisit
                {
                    BlogPage = blogPage,
                    Browser = browser
                });

                db.SaveChanges();
            }

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
