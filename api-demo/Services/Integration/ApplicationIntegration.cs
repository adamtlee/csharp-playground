using System;
using ApiDemo.Services.Pokemon;

namespace ApiDemo.Services.Integration
{
	public class ApplicationIntegration : IIntegrationService
	{
		private readonly IPokemonClient _pokemonClient;
		public ApplicationIntegration(IPokemonClient pokemonClient)
		{
			_pokemonClient = pokemonClient; 
		}

		public async Task Run()
		{
            await GetPokemonMove();
            await GetResource();
			
		}

		public async Task GetResource()
		{
			var response = await _pokemonClient.GetPokemonUrl();

			foreach(var p in response)
			{
				Console.WriteLine($"name: {p.name}");
				Console.WriteLine($"url: {p.url}");
			}
		}

		public async Task GetPokemonMove()
		{
			// Todo: refactor this
			var response = await _pokemonClient.GetPokemonMoves();

			Console.WriteLine($"id: {response.id}");
            Console.WriteLine($"name: {response.name}");
			foreach(var n in response.names)
			{
				Console.WriteLine($"names name: {n.name}");
                Console.WriteLine($"names url: {n.url}");

            }
			foreach(var d in response.descriptions)
			{
                Console.WriteLine($"descriptions language: {d.language.name}");
                Console.WriteLine($"descriptions description: {d.description}");
            }
           
            
		}
	}
}

