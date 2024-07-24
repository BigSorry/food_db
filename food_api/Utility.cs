using System.Text.Json;
using Data;

namespace Utility;
public static class JsonFileReader
{
    public static async Task<T> ReadAsync<T>(string filePath)
    {
        using FileStream stream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    public static List<T> ReadJson<T>(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            string jsonContent = File.ReadAllText(filePath);
            jsonContent = jsonContent.Trim();
            return JsonSerializer.Deserialize<List<T>>(jsonContent, options);

        }
        catch (JsonException ex)
        {
            throw new Exception($"Failed to deserialize JSON from file '{filePath}': {ex.Message}", ex);
        }

    }
}

public static class ObjectMapper
{
    public static List<Recipe> RecipeMapper(List<JsonRecipe> jsonRecipes)
    {
        List<Recipe> recipes = new List<Recipe>();
        Dictionary<string, string> uniqueRecipes = new Dictionary<string, string>();
        foreach (JsonRecipe JsonRecipe in jsonRecipes)
        {
            Recipe recipe = new Recipe
            {
                Name = JsonRecipe.Name,
                Description = JsonRecipe.Description,
                Instructions = string.Join(string.Empty, JsonRecipe.Method.ToArray()),
                Url = JsonRecipe.Url
            };
            if (uniqueRecipes.ContainsKey(recipe.Name) == false)
            {
                recipes.Add(recipe);
                uniqueRecipes.Add(recipe.Name, "");

            }
        }
        return recipes;
    }

    public static Ingredient IngredientMap(JsonRecipe jsonRecipe)
    {
        return SeedData.GetPancakeIngredients()[0];
    }

    public static RecipeIngredient RecipeIngredientMap(JsonRecipe jsonRecipe)
    {
        return SeedData.GetPancakeRecipeIngredients()[0];
    }
}
