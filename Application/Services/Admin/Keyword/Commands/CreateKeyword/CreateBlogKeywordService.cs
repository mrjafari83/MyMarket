using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.ViewModels;
using Application.Interfaces.Context;
using Domain.Entities.Common;
using Domain.Entities.BlogPages;

namespace Application.Services.Admin.Keyword.Commands.CreateKeyword
{

    public static class CreateBlogKeywordService
    {
        public static ResultDto Execute(KeywordViewModel keyword, int blogId, IDataBaseContext db)
        {
            db.BlogKeywords.Add(new Keyword<BlogPage>
            {
                Value = keyword.KeywordValue,
                Parent = db.BlogPages.Find(blogId)
            });

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
