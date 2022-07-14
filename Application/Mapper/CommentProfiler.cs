using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Application.Services.Admin.Comment.Queries.GetAllComments;
using Persistance.Entities.Comments;
using Persistance.Entities.Products;
using Persistance.Entities.BlogPages;

namespace Application.Mapper
{
    public class CommentProfiler : Profile
    {
        public CommentProfiler()
        {
            CreateProjection<Comment<Product>, CommentViewModel>()
                .ForMember(d => d.PageId, i => i.MapFrom(s => s.Location.Id == null ? 0 : s.Location.Id))
                .ForMember(d => d.ParentId, i => i.MapFrom(s => s.Parent.Id == null ? 0 : s.Location.Id));
            CreateProjection<Comment<BlogPage>, CommentViewModel>()
                .ForMember(d => d.PageId, i => i.MapFrom(s => s.Location.Id == null ? 0 : s.Location.Id))
                .ForMember(d => d.ParentId, i => i.MapFrom(s => s.Parent.Id == null ? 0 : s.Location.Id));
        }
    }
}
