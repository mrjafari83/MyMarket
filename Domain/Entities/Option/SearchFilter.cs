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

namespace Domain.Entities.Option
{
    public class SearchFilter : BaseEntity
    {
        [Column(TypeName = "xml")]
        public string FilterXml { get; set; }
    }
}
