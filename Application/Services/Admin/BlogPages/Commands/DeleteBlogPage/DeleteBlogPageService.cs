using System;
using Common.Dto;
using Application.Interfaces.Context;
using Common.Utilities;
using System.Threading.Tasks;

namespace Application.Services.Admin.BlogPages.Commands.DeleteBlogPage
{
    public class DeleteBlogPageService : IDeleteBlogPageService
    {
        private readonly IDataBaseContext db;
        public DeleteBlogPageService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var page = await db.BlogPages.FindAsync(id);

            page.IsRemoved = true;
            page.RemoveTime = DateTime.Now;
            FileUploader.Delete(page.Image);
            
            db.BlogPages.Update(page);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "صفحه حذف شد."
            };
        }
    }
}
