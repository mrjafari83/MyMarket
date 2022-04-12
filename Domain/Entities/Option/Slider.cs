using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Products;
using Domain.Entities.Common;

namespace Domain.Entities.Option
{
    public class Slider : BaseEntity
    {
        public virtual Product Product { get; set; }
    }
}
