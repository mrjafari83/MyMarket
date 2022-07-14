using Common.Dto;
using Persistance.Context;
using Persistance.Entities.Comments;
using System.Threading.Tasks;

namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public class CreateBlogPageCommentService : ICreateCommentService
    {
        private readonly IDataBaseContext db;
        public CreateBlogPageCommentService(IDataBaseContext context)
        {
            db = context;
        }

        public async  Task<ResultDto> Execute(CreateCommentDto comment)
        {
            await db.BlogPageComments.AddAsync(new Comment<Persistance.Entities.BlogPages.BlogPage>
            {
                Name = comment.Name,
                Email = comment.Email,
                Text = comment.Text,
                CreateDate = System.DateTime.Now,
                ImageSrc = comment.ImageSrc,
                Location = db.BlogPages.Find(comment.PageId),
                Parent = db.BlogPageComments.Find(comment.ParentId) ?? null,
                
            });

            await db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کامنت افزوده شد."
            };
        }
    }
}
