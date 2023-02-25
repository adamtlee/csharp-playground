using System;
using System.Text.Json;
using Microsoft.Extensions.Http;
using ApiDemo.Models;
using Microsoft.Extensions.Configuration;

namespace ApiDemo.Services.Pokemon
{
    public class PokemonClient : IPokemonClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PokemonClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<PokemonUrl>> GetPokemonUrl()
        {
            var client = _httpClientFactory.CreateClient("PokemonClient");

            var response = await client.GetAsync("pokemon");
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

            return pokemonUrls;
        }

        public async Task<ApiDemo.Models.Pokemon> GetPokemonMoves()
        {
            var client = _httpClientFactory.CreateClient("PokemonClient");
            var response = await client.GetAsync("move-target/1/");
            response.EnsureSuccessStatusCode();
            var pokemonMoves = new ApiDemo.Models.Pokemon(); 
            var content = await response.Content.ReadAsStringAsync();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                 pokemonMoves = JsonSerializer.Deserialize<ApiDemo.Models.Pokemon>(content,
                 new JsonSerializerOptions()
                 {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                 });
            }

            return pokemonMoves; 
        }
    }
}

