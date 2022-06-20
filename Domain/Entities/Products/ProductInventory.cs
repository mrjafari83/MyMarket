using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Products
{
    public class ProductInventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }

        public Product Product { get; set; }
    }
}
