using Culinista.Crawlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Culinista.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrawlerController : ControllerBase
    {
        [HttpGet]
        public async Task<RecipePreview> GetRecipePreview([FromQuery] string url)
        {
            var recipePreview = new RecipePreview();
            await recipePreview.CrawlRecipePreview(url);
            return recipePreview;
        }
    }
}
