using Culinista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culinista.Context
{
    public static class InitialData
    {
        internal static void Seed(this RecipeContext dbContext)
        {
            if (!dbContext.Recipes.Any())
            {
                //dbContext.Recipes.Add(new Recipe
                //{
                    
                //    Title = "Paprikasoep",
                //    Ingredients = "Paprika"
                //});

                //dbContext.Recipes.Add(new Recipe
                //{
                //    Title = "Erwtensoep",
                //    Ingredients = "Erwten"
                //});

                //dbContext.SaveChanges();
            }
        }
    }
}
