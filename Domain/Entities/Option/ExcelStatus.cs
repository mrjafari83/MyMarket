using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Option
{
    public class ExcelStatus : BaseEntity
    {
        public int Status { get; set; } = 0;
        public string FileName { get; set; }
        public int SearchFilterId { get; set; }
        public SearchFilter SearchFilter { get; set; }
    }
}
