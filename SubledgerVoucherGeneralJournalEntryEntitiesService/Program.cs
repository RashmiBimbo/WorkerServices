using Newtonsoft.Json.Linq;
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
        string solnPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        string configName = "Config.json";

        // Set of registered types to avoid duplicates
        HashSet<Type> registeredTypes = [];

        string result = File.ReadAllText(solnPath + "\\" + configName);
        JObject obj = JObject.Parse(result);
        JArray Items = (JArray)obj["SqlIntegrationServices"];

        // Iterate over the services to configure
        foreach (var itm in Items)
        {
            string itmJsn;
            for (int cnt = 1; cnt <= 2; cnt++)
            {
                try
                {
                    itmJsn = Serialize.ToJson(itm);
                    var service = JsonConvert.DeserializeObject<Service>(itmJsn);
                    if (service.ServiceConfiguration.Run)
                    {
                        string namespaceName = service.Name + "Service"; // Or the correct namespace
                        string workerTypeName = $"{namespaceName}.{service.Name}Worker";

                        // Attempt to get the type
                        var workerType = Type.GetType(workerTypeName, throwOnError: false, ignoreCase: true);

                        if (workerType != null)
                        {
                            // Check if the type implements IHostedService
                            if (typeof(IHostedService).IsAssignableFrom(workerType))
                            {
                                if (registeredTypes.Add(workerType))
                                // Register the worker as a singleton service
                                {
                                    // Register the configuration instance as a singleton
                                    serviceCln.AddSingleton(service.ServiceConfiguration);

                                    // Register the worker type as a singleton service
                                    serviceCln.AddSingleton(typeof(IHostedService), workerType);
                                    //serviceCln.AddTransient(typeof(IHostedService), workerType);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The type {workerType.FullName} does not implement IHostedService.");
                            }
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                }
            }
        }

        serviceCln.AddDbContext<ServiceDbContext>(options =>
            options.UseSqlServer(
                hostBuilderCntxt.Configuration.GetConnectionString("MFELDynamics365")
                ?? throw new InvalidOperationException("Connection string 'MFELDynamics365' not found."), options => options.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));
        serviceCln.AddLogging(); // Ensure logging is configured }

    }
}