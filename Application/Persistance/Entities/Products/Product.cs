using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Persistance.Entities.Common;
using Application.Persistance.Entities.Categories;
using Application.Persistance.Entities.Products.Relations;
using Application.Persistance.Entities.Comments;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Application.Persistance.Entities.Cart;

namespace Application.Persistance.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ShortDescription { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category<Product> Category { get; set; }
        public virtual ICollection<ProductFeature> Features { get; set; }
        public virtual ICollection<SizeInProduct> Sizes { get; set; }
        public virtual ICollection<ColorInProduct> Colors { get; set; }
        public virtual ICollection<Keyword<Product>> Keywords { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<Comment<Product>> Comments { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
        public virtual ICollection<ProductsVisit> Visits { get; set; }
        public virtual ICollection<ProductInventory> Inventories { get; set; }
    }
}
