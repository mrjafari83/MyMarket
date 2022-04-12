using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Comments;

namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public class CreateBlogPageCommentService : ICreateCommentService
    {
        private readonly IDataBaseContext db;
        public CreateBlogPageCommentService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CreateCommentDto comment)
        {
            db.BlogPageComments.Add(new Comment<Domain.Entities.BlogPages.BlogPage>
            {
                Name = comment.Name,
                Email = comment.Email,
                Text = comment.Text,
                CreateDate = System.DateTime.Now,
                ImageSrc = comment.ImageSrc,
                Location = db.BlogPages.Find(comment.PageId),
                Parent = db.BlogPageComments.Find(comment.ParentId) ?? null,
                
            });

            db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کامنت افزوده شد."
            };
        }
    }
}
