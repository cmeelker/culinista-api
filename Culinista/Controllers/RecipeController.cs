using Culinista.Context;
using Culinista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
            return _recipeContext.Recipes.Include("Ingredients.Ingredient").ToList();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _recipeContext.Recipes.Include("Ingredients.Ingredient").FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Recipe value)
        {
            _recipeContext.Recipes.Add(value);
            _recipeContext.SaveChanges();
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
