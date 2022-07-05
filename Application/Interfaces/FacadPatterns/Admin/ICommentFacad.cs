using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Comment.Queries.GetAllComments;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface ICommentFacad
    {
        IGetAllCommentsService GetAllProductComments { get; }
        IGetAllCommentsService GetAllBlogComments { get; }
    }
}