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
        public IEnumerable<Recipe> Get()
        {
            return _recipeContext.Recipes.ToList();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public int Post([FromBody] Recipe recipe)
        {
            _recipeContext.Recipes.Add(recipe);
            _recipeContext.SaveChanges();
            return recipe.Id;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recipe value)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
            if (recipe != null)
            {
                _recipeContext.Entry<Recipe>(recipe).CurrentValues.SetValues(value);
                _recipeContext.SaveChanges();
            }
        }

        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] Recipe value)
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
        public void Delete(int id)
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
