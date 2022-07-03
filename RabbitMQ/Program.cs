using Application.FacadPatterns.Admin;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using RabbitMQ;
using RabbitMQ.Excel;
using Application.Services.Admin.Options.Queries.GetAllProductDetails;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IDataBaseContext, DataBaseContext>();
        services.AddHostedService<RabbitBackService>();
        services.AddSingleton<IRecive, Recive>();
        services.AddScoped<IGetExcel, GetExcel>();
        services.AddScoped<IExcelFacade, ExcelFacade>();
        services.AddScoped<IOptionFacade, OptionFacade>();

        services.AddDbContext<DataBaseContext>(optons =>
            optons.UseSqlServer(@"Data Source= .; Initial Catalog= Market_DB; Integrated Security= False;User Id=sa;Password=123;")
        );
    })
    .Build();

await host.RunAsync();