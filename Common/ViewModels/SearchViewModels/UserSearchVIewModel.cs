using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels.SearchViewModels
{
    public class UserSearchVIewModel
    {
        public string SearchKey { get; set; } = "";
        public Enums.Enums.UserSearchFilter SearchBy { get; set; } = Enums.Enums.UserSearchFilter.Name;
        public Enums.Enums.RolesWithAll UserRole { get; set; }
    }
}
