using LehoczkyMark_QGXUN0.Main.PokemonValues;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9week
{
    internal class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public PokemonDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase("pokemon").UseLazyLoadingProxies();
        }
    }
}
