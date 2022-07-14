using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Client.Products.Commands.AddNewVisit
{
    public class AddNewVisitService : IAddNewVisitService
    {
        private readonly IDataBaseContext db;
        public AddNewVisitService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id, string browserCode)
        {
            var product = db.Products.Find(id);
            var browser = db.Browsers.Where(b => b.BrowserCode == browserCode).FirstOrDefault();

            if(!db.ProductsVisits.Where(p=> p.Product == product && p.Browser == browser).Any())
            {
                db.ProductsVisits.Add(new Application.Persistance.Entities.Products.Relations.ProductsVisit
                {
                    Product = product,
                    Browser = browser
                });

                db.SaveChanges();
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
