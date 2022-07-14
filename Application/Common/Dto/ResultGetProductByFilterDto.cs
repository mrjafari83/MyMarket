using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Common.Dto
{
    public class ResultGetProductByFilterDto
    {
        public int TotalRows { get; set; }
        public List<GetProductByFilterDto> Products { get; set; }
    }
}
