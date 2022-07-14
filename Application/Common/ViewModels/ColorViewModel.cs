using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class ColorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا نام رنگ را وارد کنید.")]
        public string Name { get; set; }
    }

    public class ColorViewModelCreate
    {

        [Required(ErrorMessage = "لطفا نام رنگ را وارد کنید.")]
        public string Name { get; set; }
    }
}
