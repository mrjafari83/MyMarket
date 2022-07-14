using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.ViewModels;

namespace Application.Common.Dto
{
    public class ResultGetAllCommentsDto
    {
        public int TotalRows { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
