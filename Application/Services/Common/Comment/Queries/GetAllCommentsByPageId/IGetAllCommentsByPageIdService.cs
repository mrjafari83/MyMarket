using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Common.Comment.Queries.GetAllCommentsByPageId
{
    public interface IGetAllCommentsByPageIdService
    {
        Task<ResultDto<List<GetAllCommentsByPageIdDto>>> Execute(int pageId);
    }
}
