using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Application.Persistance.Entities.Categories;
using Application.Persistance.Entities.Common;
using Application.Persistance.Entities.Comments;
using Application.Persistance.Entities.Products;
using Application.Persistance.Entities.Products.Relations;
using Application.Persistance.Entities.BlogPages;
using Application.Persistance.Entities.Option;
using Application.Persistance.Entities.Cart;
using Application.Persistance.Entities.User;
using Application.Persistance.Entities.NewsBulletin;
using Application.Persistance.Entities.Message;

namespace Application.Persistance.Context
{
    public interface IDataBaseContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductFeature> ProductFutures { get; set; }
        DbSet<ProductSize> ProductSizes { get; set; }
        DbSet<ProductColor> ProductColors { get; set; }
        DbSet<Category<Product>> ProductCategories { get; set; }
        DbSet<BlogPage> BlogPages { get; set; }
        DbSet<BlogPagesVisit> BlogPagesVisits { get; set; }
        DbSet<Category<BlogPage>> BlogPageCategories { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductsVisit> ProductsVisits { get; set; }
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
        DbSet<CriticismMessage> CriticismMessages { get; set; }
        DbSet<Browser> Browsers { get; set; }
        DbSet<ProductInventory> ProductInventories { get; set; }
        DbSet<Excel> Excels { get; set; }

        //relation tables
        DbSet<ColorInProduct> ColorsInProducts { get; set; }
        DbSet<SizeInProduct> SizesInProducts { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
