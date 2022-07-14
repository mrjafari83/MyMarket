using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Entities.Common
{
    public class Keyword<Type> : BaseEntity
    {
        public string Value { get; set; }

        public virtual Type Parent { get; set; }
    }
}
