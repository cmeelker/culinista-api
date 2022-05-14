﻿using Culinista.Models;
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
            var servings = AH.GetNumberOfServings(htmlDocument);

            Recipe recipe = new()
            {
                Title = title,
                Ingredients = ingredients,
                Servings = servings,
                Instructions = instructions,
                Source = Source.AH,
                
            };

            return recipe;
        }
        private static string GetTitle(HtmlDocument htmlDocument)
        {
            var titleXPath = "//h1";
            var title = htmlDocument.DocumentNode.SelectSingleNode(titleXPath).InnerText;
            return title;
        }

        private static IngredientUnit[] GetIngredients(HtmlDocument htmlDocument)
        {
            var ingredientNames = new List<string>();
            var ingredientNameDivs = htmlDocument.DocumentNode.SelectNodes("//p[contains(@class, 'ingredient_name')]");
            foreach (var div in ingredientNameDivs)
            {
                var ingredient = div.InnerText;
                ingredientNames.Add(ingredient);
            }

            var ingredientUnits = new List<string>();
            var ingredientUnitDivs = htmlDocument.DocumentNode.SelectNodes("//p[contains(@class, 'ingredient_unit')]");
            foreach (var div in ingredientUnitDivs)
            {
                var unit = div.InnerText;
                ingredientUnits.Add(unit);
            }

            var ingredients = new List<IngredientUnit>();
            for (int i = 0; i < ingredientNames.Count; i++)
            {
                var ingredient = new IngredientUnit
                {
                    Name = ingredientNames[i],
                    Unit = ingredientUnits[i]
                };
                ingredients.Add(ingredient);
            }

            return ingredients.ToArray();
        }

        private static string GetInstructions(HtmlDocument htmlDocument)
        {
            var instructions = new List<string>();
            var preperationDivs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("recipe-steps_step__FYhB8")).ToList();
            foreach (var div in preperationDivs)
            {
                var preparation = div.Descendants("p").FirstOrDefault().InnerText;
                instructions.Add(preparation);
            }

            return String.Join(";", instructions.ToArray());
        }

        private static int GetNumberOfServings(HtmlDocument htmlDocument)
        {
            var numberOfServingsString = htmlDocument.DocumentNode.Descendants("p").Where(node => node.Attributes["class"].Value.Contains("recipe-ingredients_count")).FirstOrDefault().InnerText;
            var numberOfServings = Int32.Parse(numberOfServingsString.Split(" ")[0]);
            return numberOfServings;
        }
    }
}