using BlazorPokedex.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPokedex.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            var pokemonApi = await _httpClient.GetStringAsync($"pokemon?limit=20&offset=20");
            var pokemonList = JsonConvert.DeserializeObject<ResultObject>(pokemonApi);

            var resultList = new List<Pokemon>();

            foreach (var pokemon in pokemonList.Pokemons)
            {
                resultList.Add(await GetPokemon(pokemon.Name));
            }

            return resultList;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {   
            return JsonConvert.DeserializeObject<Pokemon>(await _httpClient.GetStringAsync($"pokemon/{name}"));
        }
    }
}
