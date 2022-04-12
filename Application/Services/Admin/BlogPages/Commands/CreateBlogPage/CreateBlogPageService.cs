using System;
using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.BlogPages;
using Domain.Entities.Common;
using System.Collections.Generic;
using Domain.Entities.Products;
using Common.ViewModels;

namespace Application.Services.Admin.BlogPages.Commands.CreateBlogPage
{
    public class CreateBlogPageService : ICreateBlogPageService
    {
        private readonly IDataBaseContext db;
        public CreateBlogPageService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(CreateBlogPageDto entry)
        {
            BlogPage blogPage = new BlogPage()
            {
                Title = entry.Title,
                ShortDescription = entry.ShortDescription,
                Text = entry.Text,
                Image = entry.Image,
                Category = db.BlogPageCategories.Find(entry.CategoryId),
                CreateDate = DateTime.Now,
                VisitNumber = 0
            };

            db.BlogKeywords.AddRange(AddKeywords(blogPage , entry.Keywords));
            db.BlogPages.Add(blogPage);
            db.SaveChanges();
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
