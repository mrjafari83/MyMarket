using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Classes
{
    public abstract class Roles
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public abstract void SetName(string name);

        public abstract void SetFamily(string family);
    }

    public class ImplementRoles : Roles
    {
        public override void SetFamily(string family)
        {
            Family = family;
        }

        public override void SetName(string name)
        {
            Name = name;
        }
    }
}
