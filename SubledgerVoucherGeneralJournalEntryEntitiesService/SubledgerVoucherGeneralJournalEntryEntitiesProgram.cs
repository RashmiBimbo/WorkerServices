using SubledgerVoucherGeneralJournalEntryEntitiesService;


var builder = Host.CreateDefaultBuilder(args);
builder = builder.ConfigureServices((context, services) =>
    {
        services.AddDbContext<SubledgerVoucherGeneralJournalEntryEntitiesContext>(options =>
            options.UseSqlServer(
                context.Configuration.GetConnectionString("MFELDynamics365")
                ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."), options => options.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        services.AddSingleton<SubledgerVoucherGeneralJournalEntryEntitiesWorker>();
        services.AddHostedService(provider => provider.GetRequiredService<SubledgerVoucherGeneralJournalEntryEntitiesWorker>());
        services.AddLogging(); // Ensure logging is configured
    });

var host = builder.Build();
host.Run();
