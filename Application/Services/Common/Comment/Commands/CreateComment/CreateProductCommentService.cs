using Application.Common.Dto;
using Application.Persistance.Context;
using Application.Persistance.Entities.Comments;
using System.Threading.Tasks;

namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public class CreateProductCommentService : ICreateCommentService
    {
        private readonly IDataBaseContext db;
        public CreateProductCommentService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(CreateCommentDto comment)
        {
            await db.ProductComments.AddAsync(new Comment<Application.Persistance.Entities.Products.Product>
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

            await db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کامنت افزوده شد."
            };
        }
    }
}
