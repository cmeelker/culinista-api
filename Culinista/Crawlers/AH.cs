using Culinista.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Culinista.Crawlers
{
    public class AH
    {
        public static async Task<Recipe> CrawlRecipeAsync(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var title = AH.GetTitle(htmlDocument);
            var ingredients = AH.GetIngredients(htmlDocument);
            var instructions = AH.GetInstructions(htmlDocument);

            var recipe = new Recipe
            {
                Title = title,
                Ingredients = ingredients,
                Instructions = instructions
            };

            return recipe;
        }
        private static string GetTitle(HtmlDocument htmlDocument)
        {
            var titleXPath = "//h1";
            var title = htmlDocument.DocumentNode.SelectSingleNode(titleXPath).InnerText;
            return title;
        }

        private static Ingredient[] GetIngredients(HtmlDocument htmlDocument)
        {
            var ingredientNames = new List<string>();
            var ingredientNameDivs = htmlDocument.DocumentNode.Descendants("p").Where(node => node.Attributes["class"].Value.Contains("recipe-ingredients-list_name")).ToList();
            foreach (var div in ingredientNameDivs)
            {
                var ingredient = div.InnerText;
                ingredientNames.Add(ingredient);
            }

            var ingredientUnits = new List<string>();
            var ingredientUnitDivs = htmlDocument.DocumentNode.Descendants("p").Where(node => node.Attributes["class"].Value.Contains("recipe-ingredients-list_unit")).ToList();
            foreach (var div in ingredientUnitDivs)
            {
                var unit = div.InnerText;
                ingredientUnits.Add(unit);
            }

            var ingredients = new List<Ingredient>();
            for (int i = 0; i < ingredientNames.Count; i++)
            {
                var ingredient = new Ingredient
                {
                    Name = ingredientNames[i],
                    Unit = ingredientUnits[i]
                };
                ingredients.Add(ingredient);
            }

            return ingredients.ToArray();
        }

        private static Instruction[] GetInstructions(HtmlDocument htmlDocument)
        {
            var instructions = new List<Instruction>();
            var preperationDivs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("recipe-steps_step__FYhB8")).ToList();
            foreach (var div in preperationDivs)
            {
                var preparation = div.Descendants("p").FirstOrDefault().InnerText;
                instructions.Add(new Instruction { Description = preparation});
            }

            return instructions.ToArray();
        }
    }
}
