using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Comment.Queries.GetAllComments;
using AutoMapper;

namespace Application.FacadPatterns.Admin
{
    public class CommentFacad : ICommentFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public CommentFacad(IDataBaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetAllProductCommentsService getAllProductCommentsService;
        public IGetAllCommentsService GetAllProductComments
        {
            get
            {
                return getAllProductCommentsService ?? new GetAllProductCommentsService(db, _mapper);
            }
        }

        private GetAllBlogCommentsService getAllBlogCommentsService;
        public IGetAllCommentsService GetAllBlogComments
        {
            get
            {
                return getAllBlogCommentsService ?? new GetAllBlogCommentsService(db, _mapper);
            }
        }

    }
}