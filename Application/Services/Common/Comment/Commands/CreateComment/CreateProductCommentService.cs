using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Comments;

namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public class CreateProductCommentService : ICreateCommentService
    {
        private readonly IDataBaseContext db;
        public CreateProductCommentService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CreateCommentDto comment)
        {
            db.ProductComments.Add(new Comment<Domain.Entities.Products.Product>
            {
                Name = comment.Name,
                Email = comment.Email,
                Text = comment.Text,
                ImageSrc = comment.ImageSrc,
                CreateDate = System.DateTime.Now,
                Location = db.Products.Find(comment.PageId),
                Parent = db.ProductComments.Find(comment.ParentId) ?? null,
                VisitingParent = comment.VisitingParent
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
