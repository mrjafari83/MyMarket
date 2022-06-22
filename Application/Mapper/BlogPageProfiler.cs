using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BlogPages;
using Application.Services.Admin.BlogPages.Commands.CreateBlogPage;
using Application.Services.Admin.BlogPages.Commands.EditBlogPage;
using Application.Services.Admin.BlogPages.Queries.GetBlogPageById;
using Application.Services.Common.BlogPage.Queries.GetAllBlogPages;
using Common.ViewModels;
using Domain.Entities.Common;
using Common.Utilities;

namespace Application.Mapper
{
    public class BlogPageProfiler : Profile
    {
        public BlogPageProfiler()
        {
            CreateMap<CreateBlogPageDto, BlogPage>()
                .ForMember(d => d.Keywords, i => i.MapFrom(s => s.Keywords.Select(k => new Keyword<BlogPage> { Value = k.KeywordValue })))
                .ReverseMap();
            CreateMap<EditBlogPageDto, BlogPage>()
                .ForMember(d => d.Keywords, i => i.MapFrom(s => s.Keywords.Select(k => new Keyword<BlogPage> { Value = k.KeywordValue })))
                .ReverseMap();
            CreateMap<BlogPage, GetBlogPageByIdDto>()
                .ForMember(d => d.CreateDate, i => i.MapFrom(s => s.CreateDate.ToShamsi()))
                .ForMember(d => d.CategoryName, i => i.MapFrom(s => s.Category.Name))
                .ForMember(d => d.VisitNumber, i => i.MapFrom(s => s.Visits.Count))
                .ForMember(d => d.Keywords, i => i.MapFrom(s => s.Keywords.Select(k => new KeywordViewModel { KeywordValue = k.Value })))
                .ReverseMap();
            CreateMap<BlogPage, Application.Services.Client.BlogPages.Queries.GetBlogPageById.GetBlogPageByIdDto>()
                .ForMember(d => d.CategoryName, i => i.MapFrom(s => s.Category.Name))
                .ForMember(d=> d.CreateDate,i=>i.MapFrom(s=> s.CreateDate.ToShamsi()))
                .ReverseMap();
            CreateProjection<BlogPage, GetAllBlogPagesDto>()
                .ForMember(d => d.CategoryName, i => i.MapFrom(s => s.Category.Name))
                .ForMember(d => d.CreateDate, i => i.MapFrom(s => s.CreateDate.ToShamsi()))
                .ForMember(d => d.VisitNumber, i => i.MapFrom(s => s.Visits.Count()));
        }
    }
}
