using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Domain.Entities.Option
{
    public class SearchFilter : BaseEntity
    {
        public string FilterJson { get; set; }
        public SearchItemType SearchType { get; set; }
    }

    public enum SearchItemType
    {
        Product = 0,
        BlogCategory = 1,
        ProductCategory = 2,
    }
}
