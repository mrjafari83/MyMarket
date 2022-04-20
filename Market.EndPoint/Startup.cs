using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Client;
using Application.Interfaces.FacadPatterns.Common;
using Application.FacadPatterns.Admin;
using Application.FacadPatterns.Client;
using Application.FacadPatterns.Common;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Common.Utilities.MessageSender;

namespace Market.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AdminInjections(services);
            ClientInjections(services);
            CommonInjection(services);
            InjectionUtilities(services);

            //DbContext Injection
            services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= true;")
            );

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddMvc();

            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 8;
                option.User.RequireUniqueEmail = true;
                option.Lockout.MaxFailedAccessAttempts = 10;
            }).AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        private void AdminInjections(IServiceCollection services)
        {
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IBlogPageFacad, BlogPageFacad>();
            services.AddScoped<IProductFacad, ProductFacad>();
            services.AddScoped<IProductFeatureFacad, ProductFeatureFacad>();
            services.AddScoped<IProductColorFacad, ProductColorFacad>();
            services.AddScoped<IProductSizeFacad, ProductSizeFacad>();
            services.AddScoped<IProductCategoryFacad, ProductCategoryFacad>();
            services.AddScoped<IBlogPageCategoryFacad, BlogPageCategoryFacad>();
            services.AddScoped<ISliderFacad, SliderFacad>();
            services.AddScoped<ICartPayingFacad, CartPayingsFacad>();
            services.AddScoped<ICommentFacad, CommentFacad>();
        }

        private void ClientInjections(IServiceCollection services)
        {
            services.AddScoped<IClientBlogPageFacad, ClientBlogPagesFacad>();
            services.AddScoped<IClientCartFacad, ClientCartFacad>();
        }

        private void CommonInjection(IServiceCollection services)
        {
            services.AddScoped<ICommonProductFacad, CommonProductFacad>();
            services.AddScoped<ICommonBlogPageFacad, CommonBlogPageFacad>();
            services.AddScoped<ICommonCategorisFacad, CommonCategorisFacad>();
            services.AddScoped<ICommonCommentFacad, CommonCommentFacad>();
            services.AddScoped<ICommonOptionFacad, CommonOprionFacad>();
        }

        private void InjectionUtilities(IServiceCollection services)
        {
            services.AddScoped<IMessageSender, GmailSender>();
        }
    }
}
