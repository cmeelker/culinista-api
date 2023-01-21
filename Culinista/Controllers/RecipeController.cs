using Culinista.Context;
using Culinista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Culinista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private RecipeContext _recipeContext;

        public RecipeController(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            var recipes = _recipeContext.Recipes.ToList();
            recipes.Reverse();
            return recipes;
        }

        [HttpGet("{id}")]
        public Recipe GetRecipe(int id)
        {
            return _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public int AddRecipe([FromBody] Recipe recipe)
        {
            _recipeContext.Recipes.Add(recipe);
            _recipeContext.SaveChanges();
            return recipe.Id;
        }

        [HttpPatch("{id}")]
        public void UpdateRecipe(int id, [FromBody] Recipe value)
        {
            var patchableProps = new string[] { "Tags" };

            var recipe = _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
            if (recipe != null)
            {
                var properties = typeof(Recipe).GetProperties();
                foreach (var property in properties)
                {
                    var val = property.GetValue(value);
                    if (patchableProps.Contains(property.Name)) property.SetValue(recipe, val);
                }
                _recipeContext.SaveChanges();
            }

        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
            if (recipe != null)
            {
                _recipeContext.Recipes.Remove(recipe);
                _recipeContext.SaveChanges();
            }
        }
    }
}
