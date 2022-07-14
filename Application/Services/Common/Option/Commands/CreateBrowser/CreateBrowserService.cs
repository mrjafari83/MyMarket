using System;
using Persistance.Context;
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

        public ResultDto<string> Execute()
        {
            var code = db.Browsers.Add(new Persistance.Entities.User.Browser
            {
                BrowserCode = Guid.NewGuid().ToString()
            }).Entity.BrowserCode;
            db.SaveChanges();

            return new ResultDto<string>
            {
                Data = code,
                IsSuccess = true
            };
        }
    }
}
