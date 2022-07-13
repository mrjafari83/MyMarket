using Application.FacadPatterns.Admin;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.User.Queries.GetUsersBySearch;
using Common.Utilities;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using RabbitMQ;
using RabbitMQ.Excel;
using RabbitMQ.Repositories.User.GetUsersBySearch;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IDataBaseContext, DataBaseContext>();
        services.AddHostedService<RabbitBackService>();
        services.AddSingleton<IRecive, Recive>();
        services.AddScoped<IGetExcel, GetExcel>();
        services.AddScoped<IExcelFacade, ExcelFacade>();
        services.AddScoped<IOptionFacade, OptionFacade>();
        services.AddScoped<SaveLogInFile>();
        services.AddScoped<IGetUserBySearch, GetUserBySearch>();

        services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= False;User Id=sa;Password=123;")
        );

        services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
        {
            option.Password.RequireLowercase = false;
            option.Password.RequireUppercase = false;
            option.Password.RequiredLength = 8;
            option.User.RequireUniqueEmail = true;
            option.Lockout.MaxFailedAccessAttempts = 10;
        }).AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders();

    })
    .Build();

await host.RunAsync();