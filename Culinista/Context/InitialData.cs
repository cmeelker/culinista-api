using System.Linq;

namespace Culinista.Context
{
    public static class InitialData
    {
        internal static void Seed(this RecipeContext dbContext)
        {
            if (!dbContext.Recipes.Any())
            {
                // Add initial data here
            }
        }
    }
}
