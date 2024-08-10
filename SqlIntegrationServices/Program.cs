using CommonCode.Config;
using Microsoft.Extensions.DependencyInjection;
using SqlIntegrationServices;
using System.Reflection;

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

        // Set of registered types to avoid duplicates
        HashSet<Type> registeredTypes = [];
        string solnPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        string debugStr = @"\SqlIntegrationServices\bin\Debug";
        string rlzStr = @"\SqlIntegrationServices\bin\Release";
        StringComparison comp = StringComparison.CurrentCultureIgnoreCase;
        solnPath = solnPath.Replace(debugStr, string.Empty, comp).Replace(rlzStr, string.Empty, comp);
        string configFullPath = Path.Combine(solnPath, "Config.json");

        string ConfigJson = File.ReadAllText(configFullPath);
        //string ConfigJson = File.ReadAllText("C:\\Users\\rashmi.gupta\\source\\repos\\WorkerServices\\Config.json");

        Services services = JsonConvert.DeserializeObject<Services>(ConfigJson);
        if (services is null) return;

        IEnumerable<Type> entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes<PrimaryKeyAttribute>().Any());
        //entityTypes.Except(entityTypes.Select(p => p.Name.Contains("Base", StringComparison.CurrentCultureIgnoreCase)));
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

                        string serviceName = $"SqlIntegrationServices.{serviceDtl.Table}";
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
        // Register DbContext
        //var connectionString = hostBuilderCntxt.Configuration.GetConnectionString("DefaultConnection");
        //string connectionString = "Data Source=10.10.1.138;Initial Catalog=MFELDynamics365;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string connectionString = "Name=ConnectionStrings:DefaultConnection";
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found or is empty.");
        }

        serviceCln.AddDbContext<ServiceDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

        serviceCln.AddLogging();

        //foreach (ServiceDescriptor item in serviceCln)
        //{
        //    item.
        //}
    }
}