using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.Products;
using Persistance.Entities.Common;

namespace Persistance.Entities.Option
{
    public class Slider : BaseEntity
    {
        public string Url { get; set; }
        public string ImageSrc { get; set; }
    }
}
