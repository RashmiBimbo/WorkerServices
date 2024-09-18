using SqlIntegrationServices;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                    {
                        // Ensure that user secrets are added to the configuration
                        config.AddUserSecrets<Program>();
                    })
                .ConfigureServices(AddServices);

            var host = builder.Build();
            host.Run();
        }
        catch (Exception ex)
        {
            LogInfo(ex, LogFile, NameSpacesUsed);
        }
    }

    private static void AddServices(HostBuilderContext hostBuilderCntxt, IServiceCollection serviceCln)
    {
        // Check if the type implements IHostedService
        Type worker = typeof(BaseWorker);
        if (!typeof(IHostedService).IsAssignableFrom(worker))
        {
            Console.WriteLine($"The Worker '{worker.Name}' does not implement IHostedService.");
            return;
        }

        // Set of registered types to avoid duplicates
        HashSet<Type> registeredTypes = [];
        Services services;
        try
        {
            services = ReadConfig();
            if (services is null) return;
        }
        catch (Exception)
        {
            throw;
        }

        IEnumerable<Type> entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes<PrimaryKeyAttribute>().Any());

        // Iterate over the services to configure
        foreach (ServiceDetail serviceDtl in services.ServiceSet)
        {
            string itmJsn;
            //if (serviceDtl.Name.Contains("HSNCodes") && serviceDtl.Enable)
            if (serviceDtl.Enable)
            {
                //ServiceConfiguration serviceConfig = serviceDtl.ServiceConfiguration;
                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        //string namespaceName = serviceDtl.Endpoint + "ServiceDetails"; // Or the correct namespace
                        //string serviceName = "SqlIntegrationServices.AllProductsWorker";
                        // Attempt to get the type

                        string serviceName = $"{CrntProjName}.{serviceDtl.Table}";
                        var service = Type.GetType(serviceName, throwOnError: false, ignoreCase: true);

                        if (service != null && entityTypes.Contains(service) && registeredTypes.Add(service))
                        {
                            // Register the worker as a singleton serviceDtl
                            serviceCln.AddSingleton<IHostedService>(provider =>
                            {
                                var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                                var logger = provider.GetRequiredService<ILogger<BaseWorker>>();
                                return new BaseWorker(serviceScopeFactory, logger, serviceDtl);
                            });
                        }
                        break;
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }
        // Get the connection string from configuration
        string erp_SQL_ConnStr = hostBuilderCntxt.Configuration.GetValue("ERP_SQL_ConnStr", Emp);
        //string erp_SQL_ConnStr = "Data Source=10.10.1.138;Initial Catalog=ERP_SQL_Integration;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // Register DbContext
        if (string.IsNullOrEmpty(erp_SQL_ConnStr))
        {
            throw new InvalidOperationException("Connection string 'ERP_SQL_ConnStr' not found or is empty.");
        }

        serviceCln.AddDbContext<ServiceDbContext>(options =>
            options.UseSqlServer(erp_SQL_ConnStr, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        serviceCln.AddLogging();
    }
}