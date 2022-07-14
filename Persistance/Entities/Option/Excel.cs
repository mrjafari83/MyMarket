using Persistance.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities.Option
{
    public class Excel : BaseEntity
    {
        public int Status { get; set; } = 0;
        public string FileName { get; set; }
        public string FilterJson { get; set; }
        public SearchItemType SearchType { get; set; }
    }

    public enum SearchItemType
    {
        Product = 0,
        BlogCategory = 1,
        ProductCategory = 2,
        BlogPages = 3,
        Message = 4,
        User = 5,
        Unknown = 6,
    }
}
