using System.Linq;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;
using Common.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Admin.BlogPages.Queries.GetBlogPageById
{
    public class GetBlogPageByIdService : IGetBlogPageByIdService
    {
        private readonly IDataBaseContext db;
        public GetBlogPageByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetBlogPageByIdDto> Execute(int id)
        {
            var page = db.BlogPages.Where(p => p.Id == id).Select(p => new GetBlogPageByIdDto
            {
                Id = p.Id,
                Title = p.Title,
                ShortDescription = p.ShortDescription,
                Text = p.Text,
                Image = p.Image,
                VisitNumber = p.VisitNumber,
                CategoryId = p.Category.Id,
                CategoryName = p.Category.Name,
                CreateDate = p.CreateDate.ToShamsi(),
                Keywords = p.Keywords.Select(k=> new KeywordViewModel
                {
                    KeywordValue = k.Value,
                }).ToList()
            }).FirstOrDefault();

            if (page != null)
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = page,
                    IsSuccess = true
                };
            else
                return new ResultDto<GetBlogPageByIdDto>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
