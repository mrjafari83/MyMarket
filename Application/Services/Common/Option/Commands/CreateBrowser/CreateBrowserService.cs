using System;
using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Common.Option.Commands.CreateBrowser
{
    public class CreateBrowserService : ICreateBrowserService
    {
        private readonly IDataBaseContext db;
        public CreateBrowserService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute()
        {
            db.Browsers.Add(new Domain.Entities.User.Browser
            {
                BrowserCode = Guid.NewGuid().ToString()
            });
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
