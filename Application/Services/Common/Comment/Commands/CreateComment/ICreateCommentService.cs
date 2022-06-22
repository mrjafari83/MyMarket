using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public interface ICreateCommentService
    {
        Task<ResultDto> Execute(CreateCommentDto comment);
    }
}
