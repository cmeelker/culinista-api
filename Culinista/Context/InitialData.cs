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

  //              {
  //                  "title": "Romige polenta met Italiaanse groenten en een eitje",
  //  "ingredients": [
  //    {
  //                      "ingredient": {
  //                          "name": "knoflook"
  //                      },
  //      "unit": "2 tenen"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "ongezouten roomboter"
  //                      },
  //      "unit": "80 g"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "Italiaanse roerbakgroente"
  //                      },
  //      "unit": "800 g"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "middelgrote eieren"
  //                      },
  //      "unit": "4 "
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "kraanwater"
  //                      },
  //      "unit": "1 l"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "groentebouillontablet"
  //                      },
  //      "unit": "1 "
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "polenta"
  //                      },
  //      "unit": "250 g"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "Parmigiano Reggiano"
  //                      },
  //      "unit": "80 g"
  //    },
  //    {
  //                      "ingredient": {
  //                          "name": "tuinkers"
  //                      },
  //      "unit": "1 bakje"
  //    }
  //  ],
  //  "servings": 4,
  //  "instructions": "Snijd de knoflook fijn. Verhit 30 g boter (per 4 personen) in een hapjespan en bak de knoflook en groente 5 min. op middelhoog vuur. Kook ondertussen de eieren 6 min. Laat schrikken, pel en halveer ze.;Breng ondertussen het water met de bouillontablet aan de kook. Voeg de polenta toe en laat al roerend 7 min. koken tot een dikke pap. Rasp ondertussen de kaas. Zet het vuur uit. Voeg de rest van de boter samen met de kaas toe en roer tot beide helemaal door de polenta zijn opgenomen.;Verdeel de polenta over diepe borden en leg de groente en eieren erop. Bestrooi met de tuinkers en breng op smaak met peper en eventueel zout.",
  //  "source": 0
  //}

                //dbContext.SaveChanges();
            }
        }
    }
}
