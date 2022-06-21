using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class InventoryAndPriceViewModel
    {
        public int Id { get; set; } = 0;
        public int ProductId { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
    }
}
