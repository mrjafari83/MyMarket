using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResultDto<Entity>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Entity Data { get; set; }
    }
}
