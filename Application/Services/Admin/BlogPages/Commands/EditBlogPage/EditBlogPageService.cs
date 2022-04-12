using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.BlogPages;
using Domain.Entities.Common;
using System.Collections.Generic;
using Common.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.BlogPages.Commands.EditBlogPage
{
    public class EditBlogPageService : IEditBlogPageService
    {
        private readonly IDataBaseContext db;
        public EditBlogPageService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(EditBlogPageDto entry)
        {
            var page = db.BlogPages.Include(b => b.Keywords).Where(b => b.Id == entry.Id).First();

            page.Title = entry.Title;
            page.ShortDescription = entry.ShortDescription;
            page.Text = entry.Text;
            page.Image = entry.Image;

            if (entry.CategoryId != 0)
                page.Category = db.BlogPageCategories.Find(entry.CategoryId);

            var keywords = AddKeywords(page, entry.Keywords, page.Keywords.ToList());
            DeleteKeywords(entry.Keywords, page.Keywords.ToList());
            if (keywords != null)
                db.BlogKeywords.AddRange(keywords);

            db.BlogPages.Update(page);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "صفحه با موفقیت ویرایش شد."
            };
        }

        private List<Keyword<BlogPage>> AddKeywords(BlogPage blogPage, List<KeywordViewModel> keywords, List<Keyword<BlogPage>> blogKeywords)
        {
            List<Keyword<BlogPage>> finallykeywords = new List<Keyword<BlogPage>>();
            foreach (var item in keywords)
            {
                if (blogKeywords.Where(k => k.Value == item.KeywordValue).ToList().Count() != 0)
                    continue;

                finallykeywords.Add(new Keyword<BlogPage>
                {
                    Parent = blogPage,
                    Value = item.KeywordValue
                });
            }

            return finallykeywords;
        }

        private void DeleteKeywords(List<KeywordViewModel> keywords, List<Keyword<BlogPage>> blogKeywords)
        {
            foreach (var item in blogKeywords)
            {
                if (keywords.Where(k => k.KeywordValue == item.Value).Count() == 0)
                {
                    var keyword = db.BlogKeywords.Find(item.Id);
                    keyword.IsRemoved = true;
                    keyword.RemoveTime = System.DateTime.Now;
                    db.BlogKeywords.Update(keyword);
                }
            }
        }
    }
}
