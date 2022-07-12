using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
using Common.Utilities.MessageSender;
using Domain.Entities.User;
using AutoMapper;
using Application.Mapper;
using Market.EndPoint.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Common.Utilities;
using Microsoft.Extensions.Logging;
using Application.Services.Admin.User.Queries.GetUsersBySearch;
using RabbitMQ.Repositories.User.GetUsersBySearch;

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
            MapperConfig(services);

            AdminInjections(services);
            ClientInjections(services);
            CommonInjection(services);
            InjectionUtilities(services);

            services.AddScoped<ISend, Send>();

            //DbContext Injection
            services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= False;User Id=sa;Password=123;")
            );

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddMemoryCache();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidIssuer = "Mohammad",
                    ValidAudience = "https://localhost:5001",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                };
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 8;
                option.User.RequireUniqueEmail = true;
                option.Lockout.MaxFailedAccessAttempts = 10;
            }).AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Login";
                option.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , ILoggerFactory loggerFactory)
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

            app.UseAuthentication();
            app.UseAuthorization();

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
            services.AddScoped<INewsBulletinFacad, NewsBulletinFacad>();
            services.AddScoped<IMessageFacad, MessageFacad>();
            services.AddScoped<IOptionFacade, OptionFacade>();
            services.AddScoped<IExcelFacade, ExcelFacade>();
            services.AddScoped<ICommentFacad, CommentFacad>();
            services.AddScoped<IGetUserBySearch, GetUserBySearch>();
        }

        private void ClientInjections(IServiceCollection services)
        {
            services.AddScoped<IClientBlogPageFacad, ClientBlogPagesFacad>();
            services.AddScoped<IClientCartFacad, ClientCartFacad>();
            services.AddScoped<IClientMessageFacad, ClientMessageFacad>();
            services.AddScoped<IClientProductFacad, ClientProductFacad>();
        }

        private void CommonInjection(IServiceCollection services)
        {
            services.AddScoped<ICommonProductFacad, CommonProductFacad>();
            services.AddScoped<ICommonBlogPageFacad, CommonBlogPageFacad>();
            services.AddScoped<ICommonCategorisFacad, CommonCategorisFacad>();
            services.AddScoped<ICommonCommentFacad, CommonCommentFacad>();
            services.AddScoped<ICommonOptionFacad, CommonOprionFacad>();
            services.AddScoped<ICommonCartFacad, CommonCartFacad>();
        }

        private void InjectionUtilities(IServiceCollection services)
        {
            services.AddScoped<IMessageSender, GmailSender>();
            services.AddScoped<SaveLogInFile>();
        }

        private void MapperConfig(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductProfiler());
                mc.AddProfile(new BlogPageProfiler());
                mc.AddProfile(new CartProfiler());
                mc.AddProfile(new CommentProfiler());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
