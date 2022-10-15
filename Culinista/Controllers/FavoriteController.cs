using Culinista.Context;
using Culinista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        public void EditFavorite([FromQuery] string userId, [FromQuery] int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            var favorite = _recipeContext.Favorites.FirstOrDefault(f => (f.UserId == userId) && (recipe.Id == recipeId));

            if (favorite != null)
            {
                _recipeContext.Favorites.Remove(favorite);
            }
            else
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
        public bool IsFavorite([FromQuery] string userId, [FromQuery] int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            var favorite = _recipeContext.Favorites.FirstOrDefault(f => (f.UserId == userId) && (recipe.Id == recipeId));
            return favorite != null;
        }

        [HttpGet("{id}")]
        public IEnumerable<Recipe> GetFavorites(string id)
        {
            var favorites = _recipeContext.Favorites.Include(f => f.Recipe).Where(f => f.UserId == id);
            return from fav in favorites select fav.Recipe;
        }
    }
}
