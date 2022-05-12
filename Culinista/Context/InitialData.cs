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
                //Ingredient[] ingredients = { new Ingredient { Name = "Pink Lady appel", Unit = "1" }, new Ingredient { Name = "ongezoete haverdrink", Unit = "500ml" }, new Ingredient { Name = "vezelrijke havermout grove vlokken", Unit = "100 g" } };
                //Instruction[] instructions = { new Instruction { Description = "Snijd de ongeschilde appel in blokjes van 1 cm. Breng in een pan met dikke bodem de haverdrink, havermout, kurkuma, rozijnen en de helft van de appelblokjes aan de kook." }, new Instruction { Description = "Laat op laag vuur 5-6 min. koken. Meng de kokosolie erdoor en zet het vuur uit.  Hak ondertussen de pecannoten grof." } };
                //dbContext.Recipes.Add(new Recipe
                //{

                //    Title = "Kurkuma-havermout",
                //    Ingredients = ingredients,
                //    Servings = 2,
                //    Instructions = instructions,
                //    Source = Source.AH
                //});

                dbContext.SaveChanges();
            }
        }
    }
}
