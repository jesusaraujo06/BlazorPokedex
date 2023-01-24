using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorPokedex.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("types")]
        public List<Type> Types { get; set; }

        [JsonProperty("sprites")]
        public Sprite Sprites { get; set; }
    }

    public class Type
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("type")]
        public PokemonType PokemonType { get; set; }
    }

    public class PokemonType
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Sprite
    {
        [JsonProperty("front_default")]
        public string Front { get; set; }

        [JsonProperty("back_default")]
        public string Back { get; set; }
    }
}
