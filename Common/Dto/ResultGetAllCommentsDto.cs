using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;

namespace Common.Dto
{
    public class ResultGetAllCommentsDto
    {
        public int TotalRows { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
