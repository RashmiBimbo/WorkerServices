using SalesInvoiceHeaderService;


var builder = Host.CreateDefaultBuilder(args);
builder = builder.ConfigureServices((context, services) =>
    {
        services.AddDbContext<SalesInvoiceHeadersContext>(options =>
            options.UseSqlServer(
                context.Configuration.GetConnectionString("MFELDynamics365")
                ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."), options => options.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        services.AddSingleton<SalesInvoiceWorker>();
        services.AddHostedService(provider => provider.GetRequiredService<SalesInvoiceWorker>());
        services.AddLogging(); // Ensure logging is configured
    });

var host = builder.Build();
host.Run();
