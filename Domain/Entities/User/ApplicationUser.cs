using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string ProfileImageSrc { get; set; }
    }
}
