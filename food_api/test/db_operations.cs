using Data;

public class DBController
{
    public static void PancakeExample(){
        using (var context = new RecipesContext())
        {
            Recipe pancakeRecipe = SeedData.GetPancakeRecipe();
            List<Ingredient> pancakeIngredients = SeedData.GetPancakeIngredients();
            List<RecipeIngredient> pancakeRecipeIngredients = SeedData.GetPancakeRecipeIngredients();

            context.Add(pancakeRecipe);
            foreach (Ingredient ingredient in pancakeIngredients)
            {
                context.Ingredients.Add(ingredient);
            }
            foreach (RecipeIngredient recipeIngredient in pancakeRecipeIngredients)
            {
                context.RecipeIngredients.Add(recipeIngredient);
            }

            context.SaveChanges();
        }
    }
}

