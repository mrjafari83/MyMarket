using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Domain.Entities.Categories;
using Domain.Entities.Common;
using Domain.Entities.Comments;
using Domain.Entities.Products;
using Domain.Entities.Products.Relations;
using Domain.Entities.BlogPages;
using Domain.Entities.Option;
using Domain.Entities.Cart;
using Domain.Entities.User;
using Domain.Entities.NewsBulletin;

namespace Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductFeature> ProductFutures { get; set; }
        DbSet<ProductSize> ProductSizes { get; set; }
        DbSet<ProductColor> ProductColors { get; set; }
        DbSet<Category<Product>> ProductCategories { get; set; }
        DbSet<BlogPage> BlogPages { get; set; }
        DbSet<Category<BlogPage>> BlogPageCategories { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Keyword<Product>> ProductKeywords { get; set; }
        DbSet<Keyword<BlogPage>> BlogKeywords { get; set; }
        DbSet<Comment<Product>> ProductComments { get; set; }
        DbSet<Comment<BlogPage>> BlogPageComments { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<ProductInCart> ProductsInCart { get; set; }
        DbSet<CartPayingInfo> CartPayings { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Email> Emails { get; set; }
        DbSet<News> News { get; set; }

        //relation tables
        DbSet<ColorInProduct> ColorsInProducts { get; set; }
        DbSet<SizeInProduct> SizesInProducts { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
