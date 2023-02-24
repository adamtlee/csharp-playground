namespace api_demo;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
using ApiDemo.Services.Integration;
using ApiDemo.Services.Pokemon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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


    }
}

