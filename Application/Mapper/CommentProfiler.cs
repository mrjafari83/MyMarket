using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Application.Services.Admin.Comment.Queries.GetAllComments;
using Domain.Entities.Comments;
using Domain.Entities.Products;
using Domain.Entities.BlogPages;

namespace Application.Mapper
{
    public class CommentProfiler : Profile
    {
        public CommentProfiler()
        {
            CreateMap<Comment<Product>, CommentViewModel>()
                .ForMember(d=> d.PageId,i=> i.MapFrom(s=> s.Location.Id == null ?0: s.Location.Id))
                .ForMember(d => d.ParentId, i => i.MapFrom(s => s.Parent.Id == null ? 0 : s.Location.Id))
                .ReverseMap();
            CreateMap<Comment<BlogPage>, CommentViewModel>()
                .ForMember(d => d.PageId, i => i.MapFrom(s => s.Location.Id == null ? 0 : s.Location.Id))
                .ForMember(d => d.ParentId, i => i.MapFrom(s => s.Parent.Id == null ? 0 : s.Location.Id))
                .ReverseMap();
        }
    }
}
