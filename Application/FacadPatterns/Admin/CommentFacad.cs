using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Comment.Queries.GetAllComments;

namespace Application.FacadPatterns.Admin
{
    public class CommentFacad : ICommentFacad
    {
        private readonly IDataBaseContext db;
        public CommentFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductCommentsService getAllProductCommentsService;
        public IGetAllCommentsService GetAllProductComments 
        {
            get
            {
                return getAllProductCommentsService ?? new GetAllProductCommentsService(db);
            }
        }

        private GetAllBlogCommentsService getAllBlogCommentsService;
        public IGetAllCommentsService GetAllBlogComments
        {
            get
            {
                return getAllBlogCommentsService ?? new GetAllBlogCommentsService(db);
            }
        }

    }
}
