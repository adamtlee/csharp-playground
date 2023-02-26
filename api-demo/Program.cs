namespace api_demo;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using api_demo.Models;
using ApiDemo.Models;
using ApiDemo.Services;
using ApiDemo.Services.Integration;
using ApiDemo.Services.JsonPlaceHolderClient;
using ApiDemo.Services.Pokemon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json; 

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        var serviceProvider = host.Services;

        

        try
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Host created.");

            await serviceProvider.GetService<IIntegrationService>().Run();
        }
        catch (Exception generalException)
        {
            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogError(generalException,
                "an exception happened while running the integration service.");

            Console.ReadKey();

            await host.RunAsync(); 
        }
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices(
            (serviceCollection) => ConfigureServices(serviceCollection));
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        // add loggers           
        serviceCollection.AddLogging(configure => configure.AddDebug().AddConsole());

        // serviceCollection.AddScoped<IIntegrationService, PokemonClient>();

        serviceCollection.AddScoped<IIntegrationService, ApplicationIntegration>();
        serviceCollection.AddSingleton<IPokemonClient, PokemonClient>();
        serviceCollection.AddScoped<IJsonPlaceHolderClient, JsonPlaceHolderClient>();

        serviceCollection.AddHttpClient("PokemonClient", client =>
        {
            IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();

            var ps = config.GetRequiredSection("PokemonSettings").Get<PokemonSettings>();
            // Configure the HttpClient
            client.BaseAddress = new Uri(ps.BaseUrl);
            client.Timeout = new TimeSpan(0, 0, 30);
        });

        serviceCollection.AddHttpClient("JPHClient", client =>
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

            var jp = config.GetRequiredSection("JsonPlaceHolderSettings").Get<JsonPlaceHolderSettings>();

            client.BaseAddress = new Uri(jp.BaseUrl);
            client.Timeout = new TimeSpan(0, 0, 30);
        });

        /*
        Testing
        static void Main(string[] args)
            {
                var services = new ServiceCollection();

                // Register first HttpClient with a named client
                services.AddHttpClient("Url1", client =>
                {
                    client.BaseAddress = new Uri("https://example.com/api1/");
                });

                // Register second HttpClient with a named client
                services.AddHttpClient("Url2", client =>
                {
                    client.BaseAddress = new Uri("https://example.com/api2/");
                });

                var serviceProvider = services.BuildServiceProvider();

                // Resolve first HttpClient by named client
                var httpClient1 = serviceProvider.GetService<IHttpClientFactory>().CreateClient("Url1");

                // Resolve second HttpClient by named client
                var httpClient2 = serviceProvider.GetService<IHttpClientFactory>().CreateClient("Url2");

                // Use the HttpClients as needed...
            }


        -- DI example

        public class MyService
{
    private readonly HttpClient _httpClient1;
    private readonly HttpClient _httpClient2;

    public MyService(IHttpClientFactory httpClientFactory)
    {
        // Resolve the HttpClients using named clients
        _httpClient1 = httpClientFactory.CreateClient("Url1");
        _httpClient2 = httpClientFactory.CreateClient("Url2");
    }

    // Use the HttpClients as needed...
}



         
         */
    }
}

