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

        private void AddRecipe(string userId, Recipe recipe)
        {
            Favorite newFavorite = new()
            {
                UserId = userId,
                Recipe = recipe,
            };
            _recipeContext.Favorites.Add(newFavorite);
        }

        private void DeleteRecipe(Favorite favorite)
        {
            _recipeContext.Favorites.Remove(favorite);
        }

        // TO DO: Use FromBody
        [HttpPost]
        public void ToggleFavorite([FromQuery] string userId, [FromQuery] int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                return;
            }

            bool isFavorite = _recipeContext.Favorites.Any(f => (f.UserId == userId) && (f.Recipe.Id == recipeId));

            if (isFavorite)
            {
                var favorite = _recipeContext.Favorites.FirstOrDefault(f => (f.UserId == userId) && (recipe.Id == recipeId));
                DeleteRecipe(favorite);
            }
            else
            {
                AddRecipe(userId, recipe);
            }

            _recipeContext.SaveChanges();
        }

        [HttpGet("{recipeId}")]
        public bool IsFavorite([FromQuery] string userId, int recipeId)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            var isFavorite = _recipeContext.Favorites.Any(f => (f.UserId == userId) && (f.Recipe.Id == recipeId));
            return isFavorite;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetFavorites([FromQuery] string userId)
        {
            var favorites = _recipeContext.Favorites.Include(f => f.Recipe).Where(f => f.UserId == userId);
            return from fav in favorites select fav.Recipe;
        }
    }
}
