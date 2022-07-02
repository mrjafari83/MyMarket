using Application.FacadPatterns.Admin;
using Application.FacadPatterns.Client;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Client;
using Application.Mapper;
using AutoMapper;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Persistance.Context;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= False;User Id=sa;Password=123;")
            );

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IClientCartFacad, ClientCartFacad>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
{
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 8;
    option.User.RequireUniqueEmail = true;
    option.Lockout.MaxFailedAccessAttempts = 10;
}).AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });
    c.OperationFilter<AuthResponsesOperationFilter>();
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type=ReferenceType.SecurityScheme,
    //                Id="Bearer"
    //            }
    //        },
    //        new string[]{}
    //    }
    //});
}
);

MapperConfig(builder.Services);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void MapperConfig(IServiceCollection services)
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


public class AuthResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>();

        if (authAttributes.Any())
        {
            var securityRequirement = new OpenApiSecurityRequirement()
            {
                {
                    // Put here you own security scheme, this one is an example
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            };
            operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
        }
    }
}