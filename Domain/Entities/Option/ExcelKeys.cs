using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Option
{
    public class ExcelKeys : BaseEntity
    {
        public string SearchKey { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
        public int OrderBy { get; set; }
        public int SearchBy { get; set; }
        public int Status { get; set; }
        public string FileName { get; set; }
    }
}
