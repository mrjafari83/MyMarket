using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class FeatureViewModel
    {
        [Required(ErrorMessage = "لطفا نام ویژگی را وارد کنید.")]
        public string Display { get; set; }

        [Required(ErrorMessage = "لطفا مقدار ویژگی را وارد کنید.")]
        public string FeatureValue { get; set; }
    }
}
