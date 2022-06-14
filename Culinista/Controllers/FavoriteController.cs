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
    public class FavoriteController : ControllerBase
    {
        private RecipeContext _recipeContext;

        public FavoriteController(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        [HttpPost]
        public void Post([FromQuery] string userId, [FromQuery] int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            var favorite = _recipeContext.Favorites.FirstOrDefault(f => (f.UserId == userId) && (recipe.Id == recipeId));
            
            if (favorite != null)
            {
                _recipeContext.Favorites.Remove(favorite);
            } else
            {
                Favorite newFavorite = new()
                {
                    UserId = userId,
                    Recipe = recipe,
                };
                _recipeContext.Favorites.Add(newFavorite);
            }

            _recipeContext.SaveChanges();
        }

        [HttpGet]
        public bool Get([FromQuery] string userId, [FromQuery] int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            var favorite = _recipeContext.Favorites.FirstOrDefault(f => (f.UserId == userId) && (recipe.Id == recipeId));
            return favorite != null;

        }

    }
}
