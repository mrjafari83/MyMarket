using System;
using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.BlogPages;
using Domain.Entities.Common;
using System.Collections.Generic;
using Domain.Entities.Products;
using Common.ViewModels;
using AutoMapper;
using System.Threading.Tasks;

namespace Application.Services.Admin.BlogPages.Commands.CreateBlogPage
{
    public class CreateBlogPageService : ICreateBlogPageService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public CreateBlogPageService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto> Execute(CreateBlogPageDto entry)
        {
            var blogPage = _mapper.Map<BlogPage>(entry);
            db.BlogPages.Add(blogPage);
            blogPage.Keywords = AddKeywords(blogPage, entry.Keywords);
            await db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "صفحه جدید با موفقیت اضافه شد."
            };
        }

        private List<Keyword<BlogPage>> AddKeywords(BlogPage blogPage, List<KeywordViewModel> keywords)
        {
            List<Keyword<BlogPage>> finallykeywords = new List<Keyword<BlogPage>>();
            foreach (var item in keywords)
            {
                finallykeywords.Add(new Keyword<BlogPage>
                {
                    Parent = blogPage,
                    Value = item.KeywordValue
                });
            }

            return finallykeywords;
        }
    }
}
