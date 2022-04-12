﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.BlogPages.Commands.CreateBlogPage
{
    public interface ICreateBlogPageService
    {
        ResultDto Execute(CreateBlogPageDto entry);
    }
}
