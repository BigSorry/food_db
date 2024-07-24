using Data;
using Utility;
using Controller;

public class Program
{
    static void Main(string[] args)
    {
        //insertJsonToDB();
        WebApplication app = CreateWebApplication(args);
        app.Run();
    }

    private static void insertJsonToDB()
    {
        List<JsonRecipe> jsonRecipes = JsonFileReader.ReadJson<JsonRecipe>("./recipes.json");
        List<Recipe> recipes = ObjectMapper.RecipeMapper(jsonRecipes);
        RecipesController.InsertRecipes(recipes);
    }
    private static WebApplication CreateWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("/recipes", () =>
        {
            List<Recipe> recipes = RecipesController.SelectRecipes();
            List<string> recipeUrls = RecipesController.SelectRecipesUrl();
            return Results.Json(recipeUrls);
        })
        .WithName("GetRecipes")
        .WithOpenApi();

        return app;
    }
}
