using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class InventoryAndPriceViewModel
    {
        public int Id { get; set; } = 0;
        public int ProductId { get; set; }

        [Required(ErrorMessage = "لطفا نام رنگ را وارد کنید.")]
        public string ColorName { get; set; }

        [Required(ErrorMessage = "لطفا مقدار سایز را وارد کنید.")]
        public string SizeName { get; set; }

        [Required(ErrorMessage = "لطفا موجودی کالا را وارد کنید.")]
        public int Inventory { get; set; }

        [Required(ErrorMessage = "لطفا قیمت کالا را وارد کنید.")]
        public int Price { get; set; }
    }

    public class InventoryAndPriceViewModelCreate
    {

        [Required(ErrorMessage = "لطفا نام رنگ را وارد کنید.")]
        public string ColorName { get; set; }

        [Required(ErrorMessage = "لطفا مقدار سایز را وارد کنید.")]
        public string SizeName { get; set; }

        [Required(ErrorMessage = "لطفا موجودی کالا را وارد کنید.")]
        public int Inventory { get; set; }

        [Required(ErrorMessage = "لطفا قیمت کالا را وارد کنید.")]
        public int Price { get; set; }
    }
}
