using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Products;
using Application.Persistance.Entities.Common;

namespace Application.Persistance.Entities.Option
{
    public class Slider : BaseEntity
    {
        public string Url { get; set; }
        public string ImageSrc { get; set; }
    }
}
