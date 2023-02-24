using System;
using System.Text.Json;
using ApiDemo.Models;

namespace ApiDemo.Services
{
	public class PokemonClient : IIntegrationService
	{
		private static HttpClient _httpClient = new HttpClient();
		public PokemonClient()
		{
			_httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
			_httpClient.Timeout = new TimeSpan(0, 0 , 30);
			_httpClient.DefaultRequestHeaders.Clear();
		}

		public async Task Run()
		{
			await GetPokemonUrl(); 
		}

		public async Task GetPokemonUrl()
		{
			var response = await _httpClient.GetAsync("pokemon");
			response.EnsureSuccessStatusCode();

			var pokemonUrls = new List<PokemonUrl>();
			var content = await response.Content.ReadAsStringAsync();
			if (response.Content.Headers.ContentType.MediaType == "application/json")
			{
				var pokemonData = JsonSerializer.Deserialize<PokemonData>(content,
					new JsonSerializerOptions()
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});
				if (pokemonData != null)
				{
                    pokemonUrls = pokemonData.results;
                }
			}

			// Do something with Pokemon data.
			foreach(var p in pokemonUrls)
			{
				Console.WriteLine($"Pokemon: {p.name}");
                Console.WriteLine($"Url: {p.url}");
				Console.WriteLine();
            }
		}
	}
}

