using LehoczkyMark_QGXUN0.Main.PokemonValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace _9week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pokemons = JsonConvert.DeserializeObject<PokemonList>(File.ReadAllText("pokemon.json")).Pokemon;

            var pokemonCount = pokemons.Count();

            var tallestPokemon = pokemons.Where(t => double.TryParse(t.Height.Split(' ')[0], out var h) == true).OrderByDescending(u => double.Parse(u.Height.Split(' ')[0])).FirstOrDefault();
          

            var smallPokemons = pokemons.Where(t => double.TryParse(t.Height.Split(' ')[0], out var h) == true && double.Parse(t.Height.Split(' ')[0]) < 1);
            smallPokemons.Select(t => $"{t.Name,-18} ({t.Height})");

            var smallestPokemon = pokemons.Where(t => double.TryParse(t.Height.Split(' ')[0], out var h) == true).OrderBy(u => double.Parse(u.Height.Split(' ')[0])).FirstOrDefault();

            var twoWeakness = pokemons.Where(t => t.Weaknesses.Count == 2);
            twoWeakness.Select(t => $"{t.Name,-18} {string.Join("; ", t.Weaknesses),-15} [{t.Weaknesses.Count}]");

            var thirdSmallestAvgSpawn = pokemons.OrderBy(t => t.AvgSpawns).Take(3).LastOrDefault();

            var pokemonDB = new PokemonDbContext();
            
            pokemonDB.Pokemons.AddRange(pokemons.OrderByDescending(u => u.AvgSpawns).Skip(5).Take(5));

            pokemonDB.SaveChanges();
            pokemonDB.Pokemons.Select(t => $"{t.Name,-18} ({t.AvgSpawns,6:##0.00})");

            var doc = new XDocument();
            var root = new XElement("Weaknesses");

            var weaknesses = pokemons.SelectMany(t => t.Weaknesses, (t, weakness) => weakness).Distinct().ToList();

            weaknesses.ForEach(u => root.Add(new XElement("Weakness", u)));

            doc.Add(root);
            doc.Save("weaknesses.xml");
        }
    }

    static class Extension
    {
        public static void Display<T>(this IEnumerable<T> values, string text) where T : class
        {
            Console.WriteLine(text);
            foreach (var item in values)
            {
                Console.WriteLine(" > " + item);
            }
            Console.WriteLine("-----------------------");
        }
    }
}
