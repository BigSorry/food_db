using Data;
namespace Controller;
public class RecipesController
{
    public static void InsertRecipes(List<Recipe> recipes)
    {
        using (var context = new RecipesContext())
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Description == null)
                {
                    recipe.Description = "NA";
                }
                // fix for recipe name uniqueness db propery
                // TODO refactor this check and make it smarter (e.g. establishing better rules when two recipes are deemed equal)
                bool exists = context.Recipes.Any(r => r.Name == recipe.Name);
                if (!exists)
                {
                    context.Recipes.Add(recipe);
                }
            }
            context.SaveChanges();
        }
    }

    public static List<Recipe> SelectRecipes()
    {
        using (var context = new RecipesContext())
        {
            List<Recipe> recipes = context.Recipes.ToList();
            return recipes;
        }
    }

     public static List<string> SelectRecipesUrl()
    {
        using (var context = new RecipesContext())
        {
            List<string> recipes = context.Recipes.Select(r => r.Url).ToList();
            return recipes;
        }
    }
}
