using CommonCode.Config;
using SqlIntegrationServices;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(AddServices);

        var host = builder.Build();
        host.Run();
    }

    private static void AddServices(HostBuilderContext hostBuilderCntxt, IServiceCollection serviceCln)
    {
        // Check if the type implements IHostedService
        Type worker = typeof(SqlIntegrationServices.BaseWorker);
        if (!typeof(IHostedService).IsAssignableFrom(worker))
        {
            Console.WriteLine($"The Worker '{worker.Name}' does not implement IHostedService.");
            return;
        }

        string solnPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        string configName = "Config.json";

        // Set of registered types to avoid duplicates
        HashSet<Type> registeredTypes = [];

        string result = File.ReadAllText(solnPath + "\\" + configName);

        Services services = JsonConvert.DeserializeObject<Services>(result);
        if (services is null) return;

        // Iterate over the services to configure
        foreach (ServiceDetail serviceDtl in services.ServiceList)
        {
            string itmJsn;
            //if (serviceDtl.Name.Contains("HSNCodes") && serviceDtl.ServiceConfiguration.Run)
            if (serviceDtl.Run)
            {
                ServiceConfiguration serviceConfig = serviceDtl.ServiceConfiguration;
                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        //string namespaceName = serviceDtl.Endpoint + "ServiceDetails"; // Or the correct namespace
                        //string serviceName = "SqlIntegrationServices.AllProductsWorker";
                        // Attempt to get the type

                        string serviceName = $"SqlIntegrationServices.{serviceConfig.Endpoint}";
                        var service = Type.GetType(serviceName, throwOnError: false, ignoreCase: true);

                        if (service != null)
                        {
                            if (registeredTypes.Add(service))
                            // Register the worker as a singleton serviceDtl
                            {
                                serviceCln.AddSingleton<IHostedService>(provider =>
                                {
                                    var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                                    var logger = provider.GetRequiredService<ILogger<BaseWorker>>();
                                    return new BaseWorker(serviceScopeFactory, logger, serviceConfig);
                                });
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }
        // Register DbContext
        var connectionString = hostBuilderCntxt.Configuration.GetConnectionString("MFELDynamics365");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'MFELDynamics365' not found or is empty.");
        }

        serviceCln.AddDbContext<ServiceDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        serviceCln.AddLogging();
    }
}