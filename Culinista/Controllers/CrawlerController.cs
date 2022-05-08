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
        [HttpPost]
        public Recipe Post([FromBody] string url)
        {
            var recipe = AH.CrawlRecipeAsync(url);
            return recipe.Result;
        }
    }
}
