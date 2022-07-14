using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Common.Comment.Commands.CreateComment;
using Application.Services.Common.Comment.Queries.GetAllCommentsByPageId;

namespace Application.FacadPatterns.Common
{
    public class CommonCommentFacad : ICommonCommentFacad
    {
        private readonly IDataBaseContext db;
        public CommonCommentFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductCommentsByIdService _getAllProductCommentsById;
        public IGetAllCommentsByPageIdService GetAllProductCommentsById 
        {
            get
            {
                return _getAllProductCommentsById ?? new GetAllProductCommentsByIdService(db);
            }
        }

        private GetAllBlogPageCommentsByIdService _getAllBlogPageCommentsById;
        public IGetAllCommentsByPageIdService GetAllBlogPageCommentsById
        {
            get
            {
                return _getAllBlogPageCommentsById ?? new GetAllBlogPageCommentsByIdService(db);
            }
        }

        private CreateProductCommentService _createProductComment;
        public ICreateCommentService CreateProductComment
        {
            get
            {
                return _createProductComment ?? new CreateProductCommentService(db);
            }
        }

        private CreateBlogPageCommentService _createBlogPageComment;
        public ICreateCommentService CreateBlogPageComment
        {
            get
            {
                return _createBlogPageComment ?? new CreateBlogPageCommentService(db);
            }
        }
    }
}
