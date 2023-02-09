namespace api_demo;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiDemo.Models;
using Newtonsoft.Json; 

class Program
{
    static async Task Main(string[] args)
    {
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

    }
}

