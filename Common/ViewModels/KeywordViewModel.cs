using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class KeywordViewModel
    {
        [Required(ErrorMessage = "لطفا مقدار کلمه کلیدی را وارد کنید.")]
        public string KeywordValue { get; set; }
    }
}
