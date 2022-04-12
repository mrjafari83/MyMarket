using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Comment.Queries.GetAllCommentsByPageId
{
    public interface IGetAllCommentsByPageIdService
    {
        ResultDto<List<GetAllCommentsByPageIdDto>> Execute(int pageId);
    }
}
