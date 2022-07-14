using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Comment.Queries.GetAllComments
{
    public interface IGetAllCommentsService
    {
        Task<ResultDto<ResultGetAllCommentsDto>> Execute(int pageNumber = 1 , int pageSize = 10);
    }
}
