using System;
using ApiDemo.Services.JsonPlaceHolderClient;
using ApiDemo.Services.Pokemon;

namespace ApiDemo.Services.Integration
{
	public class ApplicationIntegration : IIntegrationService
	{
		private readonly IPokemonClient _pokemonClient;

		private readonly IJsonPlaceHolderClient _jphClient; 
		public ApplicationIntegration(IPokemonClient pokemonClient, IJsonPlaceHolderClient jphClient)
		{
			_pokemonClient = pokemonClient;
			_jphClient = jphClient;
		}

		public async Task Run()
		{
			await GetJsonDataDemo();
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

		public async Task GetJsonDataDemo()
		{
			var response = await _jphClient.GetJPHResponse();

            Console.WriteLine($"Entering GetJsonDataDemo()");
            Console.WriteLine($"{response.id}");
			Console.WriteLine($"{response.title}");
            Console.WriteLine($"{response.body}");
            Console.WriteLine($"{response.userId}");
        }
	}
}

