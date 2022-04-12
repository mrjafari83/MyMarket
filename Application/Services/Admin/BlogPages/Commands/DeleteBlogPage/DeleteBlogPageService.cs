using System;
using Common.Dto;
using Application.Interfaces.Context;
using Common.Utilities;

namespace Application.Services.Admin.BlogPages.Commands.DeleteBlogPage
{
    public class DeleteBlogPageService : IDeleteBlogPageService
    {
        private readonly IDataBaseContext db;
        public DeleteBlogPageService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int id)
        {
            var page = db.BlogPages.Find(id);

            page.IsRemoved = true;
            page.RemoveTime = DateTime.Now;
            FileUploader.Delete(page.Image);
            
            db.BlogPages.Update(page);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "صفحه حذف شد."
            };
        }
    }
}
