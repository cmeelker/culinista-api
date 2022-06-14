using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culinista.Context
{
    using Culinista.Models;
    using Microsoft.EntityFrameworkCore;

    public class RecipeContext
        : DbContext
    {
        public RecipeContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientUnit> Ingredients { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
