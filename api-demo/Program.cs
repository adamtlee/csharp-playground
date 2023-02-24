namespace api_demo;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
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
        /*
        var client = new HttpClient();

        var pokemonData = new PokemonData();
        var pokemonUrls = new List<PokemonUrl>();

        string endpoint = "https://pokeapi.co/api/v2/pokemon/";

        var response = await client.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            }; 

            pokemonData = JsonConvert.DeserializeObject<PokemonData>(content);

            pokemonUrls = pokemonData.results; 
        }
        else
        {
            Console.WriteLine("Error retrieving content"); 
        }

        foreach(var p in pokemonUrls)
        {
            Console.WriteLine(p.name);
            Console.WriteLine(p.url);
        }
        */

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
        
        serviceCollection.AddScoped<IIntegrationService, PokemonClient>();

      
    }
}

