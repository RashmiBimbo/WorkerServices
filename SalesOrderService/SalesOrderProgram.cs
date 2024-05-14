var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();

//builder.Services.AddSingleton(AppDbContext, options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalTestDB") ?? throw new InvalidOperationException("Connection string 'LocalTestDB' not found.")));

builder.Services.AddDbContext<SalesOrderContext>((serviceProvider, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MFELDynamics365")
    ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."));
}, ServiceLifetime.Singleton);
builder.Services.AddHostedService<SalesOrderWorker.SalesOrderWorker>();

var host = builder.Build();
host.Run();
