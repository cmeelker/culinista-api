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

        public DbSet<Recipe> Recipes { get; set; }
    }
}
