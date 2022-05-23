using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Common;
using Domain.Entities.Categories;
using Domain.Entities.Products.Relations;
using Domain.Entities.Comments;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Entities.Cart;

namespace Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public string ShortDescription { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Category<Product> Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProductFeature> Features { get; set; }
        public virtual ICollection<SizeInProduct> Sizes { get; set; }
        public virtual ICollection<ColorInProduct> Colors { get; set; }
        public virtual ICollection<Keyword<Product>> Keywords { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<Comment<Product>> Comments { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
        public virtual ICollection<ProductsVisit> Visits { get; set; }
    }
}
