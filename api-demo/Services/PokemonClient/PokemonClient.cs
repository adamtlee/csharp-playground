using System;
using System.Text.Json;
using ApiDemo.Models;
using Microsoft.Extensions.Configuration;

namespace ApiDemo.Services.Pokemon
{
    public class PokemonClient : IPokemonClient
    {
        private static HttpClient _httpClient = new HttpClient();
        public PokemonClient()
        {
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<List<PokemonUrl>> GetPokemonUrl()
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

            return pokemonUrls;
        }

        public async Task<ApiDemo.Models.Pokemon> GetPokemonMoves()
        {
            var response = await _httpClient.GetAsync("move-target/1/");
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

