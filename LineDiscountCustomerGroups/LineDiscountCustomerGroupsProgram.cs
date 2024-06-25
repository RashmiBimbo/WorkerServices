using SqlIntegrationServices;


var builder = Host.CreateDefaultBuilder(args);
builder = builder.ConfigureServices((context, services) =>
    {
        services.AddDbContext<LineDiscountCustomerGroupsContext>(options =>
            options.UseSqlServer(
                context.Configuration.GetConnectionString("MFELDynamics365")
                ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."), options => options.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        services.AddSingleton<LineDiscountCustomerGroupsWorker>();
        services.AddHostedService(provider => provider.GetRequiredService<LineDiscountCustomerGroupsWorker>());
        services.AddLogging(); // Ensure logging is configured
    });

var host = builder.Build();
host.Run();
