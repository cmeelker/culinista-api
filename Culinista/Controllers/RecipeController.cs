using Culinista.Context;
using Culinista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _recipeContext.Recipes;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Recipe value)
        {
            _recipeContext.Recipes.Add(value);
            _recipeContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recipe value)
        {
            var employee = _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _recipeContext.Entry<Recipe>(employee).CurrentValues.SetValues(value);
                _recipeContext.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _recipeContext.Recipes.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _recipeContext.Recipes.Remove(student);
                _recipeContext.SaveChanges();
            }
        }
        //private readonly IConfiguration _configuration;

        //public RecipeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[HttpGet]
        //public IEnumerable<Recipe> Get()
        //{
        //    var recipes = GetRecipes();
        //    return recipes;
        //}
        //private IEnumerable<Recipe> GetRecipes()
        //{
        //    var recipes = new List<Recipe>();
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("Database")))
        //    {
        //        var sql = "SELECT * FROM Recipes";
        //        connection.Open();
        //        using SqlCommand command = new SqlCommand(sql, connection);
        //        using SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var recipe = new Recipe()
        //            {
        //                Id = (int)reader["Id"],
        //                Title = reader["Title"].ToString(),
        //                Ingredients = reader["Ingredients"].ToString(),
        //            };
        //            recipes.Add(recipe);
        //        }
        //    }
        //    return recipes;
        //}
    }
}
