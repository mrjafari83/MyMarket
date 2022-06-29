using Application.FacadPatterns.Admin;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Mapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Persistance.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
}
);

builder.Services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= False;User Id=sa;Password=123;")
            );

MapperConfig(builder.Services);

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
