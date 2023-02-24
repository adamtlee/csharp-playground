using ApiDemo.Models;

namespace ApiDemo.Services.Pokemon
{
    public interface IPokemonClient
    {
        Task<List<PokemonUrl>> GetPokemonUrl();
        Task<ApiDemo.Models.Pokemon> GetPokemonMoves();
    }
}