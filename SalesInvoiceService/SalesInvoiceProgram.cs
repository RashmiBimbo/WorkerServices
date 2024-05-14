using Microsoft.Extensions.DependencyInjection;
using SalesInvoiceService;


var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();

//builder.Services.AddSingleton(AppDbContext, options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalTestDB") ?? throw new InvalidOperationException("Connection string 'LocalTestDB' not found.")));

builder.Services.AddDbContext<SalesInvoiceContext>((serviceProvider, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MFELDynamics365")
    ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."));
}, ServiceLifetime.Singleton);
builder.Services.AddHostedService<SalesInvoiceWorker>();

var host = builder.Build();
host.Run();