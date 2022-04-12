using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class EditUserRolesViewModel
    {
        public string UserName { get; set; }
        public bool Customer { get; set; }
        public bool Admin { get; set; }
        public bool Owner { get; set; }
    }
}
