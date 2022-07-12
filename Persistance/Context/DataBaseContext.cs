using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Products;
using Domain.Entities.Products.Relations;
using Domain.Entities.Categories;
using Domain.Entities.BlogPages;
using Domain.Entities.Common;
using Domain.Entities.Comments;
using Domain.Entities.Option;
using Domain.Entities.Cart;
using Domain.Entities.User;
using Common.Classes;
using Domain.Entities.NewsBulletin;
using Domain.Entities.Message;
using Microsoft.AspNetCore.Identity;

namespace Persistance.Context
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser , ApplicationRole , string>, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFutures { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductsVisit> ProductsVisits { get; set; }
        public DbSet<Category<Product>> ProductCategories { get; set; }
        public DbSet<BlogPage> BlogPages { get; set; }
        public DbSet<BlogPagesVisit> BlogPagesVisits { get; set; }
        public DbSet<Category<BlogPage>> BlogPageCategories { get; set; }
        public DbSet<Keyword<Product>> ProductKeywords { get; set; }
        public DbSet<Keyword<BlogPage>> BlogKeywords { get; set; }
        public DbSet<Comment<Product>> ProductComments { get; set; }
        public DbSet<Comment<BlogPage>> BlogPageComments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductInCart> ProductsInCart { get; set; }
        public DbSet<CartPayingInfo> CartPayings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CriticismMessage> CriticismMessages { get; set; }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<SearchFilter> SearchFilter { get; set; }
        public DbSet<ExcelStatus> ExcelStatuses { get; set; }

        //relation tables
        public DbSet<ColorInProduct> ColorsInProducts { get; set; }
        public DbSet<SizeInProduct> SizesInProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            QueriesFilter();
            SeedData();

            void QueriesFilter()
            {
                builder.Entity<Product>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<BlogPage>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<Category<BlogPage>>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<Category<Product>>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<ProductFeature>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<ProductColor>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<Keyword<BlogPage>>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<Keyword<Product>>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<ProductSize>().HasQueryFilter(q => !q.IsRemoved);
                builder.Entity<ColorInProduct>().HasQueryFilter(cp => !cp.IsRemoved);
                builder.Entity<SizeInProduct>().HasQueryFilter(sp => !sp.IsRemoved);
                builder.Entity<Comment<Product>>().HasQueryFilter(c => !c.IsRemoved);
                builder.Entity<Comment<BlogPage>>().HasQueryFilter(c => !c.IsRemoved);
                builder.Entity<Slider>().HasQueryFilter(s => !s.IsRemoved);
                builder.Entity<Cart>().HasQueryFilter(c => !c.IsRemoved);
                builder.Entity<ProductInCart>().HasQueryFilter(pc => !pc.IsRemoved);
                builder.Entity<SearchFilter>().HasQueryFilter(e => !e.IsRemoved);
                builder.Entity<ExcelStatus>().HasQueryFilter(e => !e.IsRemoved);
            }

            void SeedData()
            {
                builder.Entity<Category<Product>>().HasData(new Category<Product>
                {
                    Id = 1383,
                    Name = "بدون دسته بندی",
                    IsParent = true,
                });

                builder.Entity<Category<BlogPage>>().HasData(new Category<Product>
                {
                    Id = 1383,
                    Name = "بدون دسته بندی",
                    IsParent = true,
                });

                builder.Entity<ApplicationRole>().HasData(new ApplicationRole
                {
                    Id = RoleNames.Customer,
                    Name = RoleNames.Customer,
                    NormalizedName = "CUSTOMER"
                });

                builder.Entity<ApplicationRole>().HasData(new ApplicationRole
                {
                    Id = RoleNames.Admin,
                    Name = RoleNames.Admin,
                    NormalizedName = "ADMIN"
                });

                builder.Entity<ApplicationRole>().HasData(new ApplicationRole
                {
                    Id = RoleNames.Owner,
                    Name = RoleNames.Owner,
                    NormalizedName = "OWNER"
                });

                builder.Entity<ApplicationUser>().HasData(new ApplicationUser
                {
                    UserName = "Management",
                    PasswordHash = "AQAAAAEAACcQAAAAEOeY3MRi9YetlUXcs10LY6ijsvl9KOBXk8hCPhOcHYeEdNHcjCWgoR2awxfbbypTSg=="
                });
            }
        }
    }
}
