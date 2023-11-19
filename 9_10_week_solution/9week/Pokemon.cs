using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _9week;

namespace LehoczkyMark_QGXUN0.Main.PokemonValues
{
    class PokemonList
    {
        [JsonProperty("pokemon")]
        public IEnumerable<Pokemon> Pokemon { get; set; }
    }

    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("num")]
        public string Num { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("img")]
        public string Img { get; set; }
        
        [JsonProperty("type")] 
        public virtual ICollection<PokemonType> Type { get; set; }
        
        [JsonProperty("height")] 
        public string Height { get; set; }
        
        [JsonProperty("weight")]
        [MaxWeight(50)] 
        public string Weight { get; set; }
        
        [JsonProperty("candy")] 
        public string Candy { get; set; }
        
        [JsonProperty("candy_count")] 
        public int CandyCount { get; set; }
        
        [JsonProperty("egg")] 
        public string Egg { get; set; }
        
        [JsonProperty("spawn_chance")] 
        public double SpawnChance { get; set; }
        
        [JsonProperty("avg_spawns")] 
        public double AvgSpawns { get; set; }
        
        [JsonProperty("spawn_time")] 
        public string SpawnTime { get; set; }
        
        [JsonProperty("multipliers")] 
        public virtual ICollection<PokemonMultipliers> Multipliers { get; set; }
        
        [JsonProperty("weaknesses")] 
        public virtual ICollection<PokemonWeaknesses> Weaknesses { get; set; }
        
        [JsonProperty("next_evolution")] 
        public virtual ICollection<PokemonEvolution> NextEvolution { get; set; }

        public Pokemon()
        {
            Type = new HashSet<PokemonType>();
            Multipliers = new HashSet<PokemonMultipliers>();
            Weaknesses = new HashSet<PokemonWeaknesses>();
            NextEvolution = new HashSet<PokemonEvolution>();
        }
    }

    public class PokemonEvolution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        
        public int PokemonId { get; set; }
        
        public virtual Pokemon Pokemon { get; set; }
        
        [JsonProperty("num")]
        public string Num { get; set; }
        
        [JsonProperty("name")] 
        public string Name { get; set; }

    }

    public class PokemonWeaknesses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        
        public int PokemonId { get; set; }
        
        public virtual Pokemon Pokemon { get; set; }
        
        public string Weaknesses { get; set; }
    }

    public class PokemonMultipliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        
        public int PokemonId { get; set; }
        
        public virtual Pokemon Pokemon { get; set; }
        
        public double Multipliers { get; set; }

        public PokemonMultipliers(double multipliers)
        {
            Multipliers = multipliers;
        }
    }

    public class PokemonType
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        
        public int PokemonId { get; set; }
        
        public virtual Pokemon Pokemon { get; set; }
     
        public string Type { get; set; }
    }
}
