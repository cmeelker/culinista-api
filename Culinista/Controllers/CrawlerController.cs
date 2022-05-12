using Culinista.Context;
using Culinista.Crawlers;
using Culinista.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Culinista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrawlerController : ControllerBase
    {
        private RecipeContext _recipeContext;

        public CrawlerController(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        [HttpPost]
        public void Post([FromBody] string url)
        {
            var recipe = AH.CrawlRecipeAsync(url);
            _recipeContext.Recipes.Add(recipe.Result);
            _recipeContext.SaveChanges();
        }
    }
}
