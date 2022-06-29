using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class SizeViewModel
    {
        [Required(ErrorMessage = "لطفا مقدار سایز را وارد کنید.")]
        public string SizeValue { get; set; }
    }
}
