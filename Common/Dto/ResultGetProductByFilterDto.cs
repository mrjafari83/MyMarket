using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Common.Dto
{
    public class ResultGetProductByFilterDto
    {
        public int TotalRows { get; set; }
        public List<GetProductByFilterDto> Products { get; set; }
    }
}
