namespace Data;

public class Recipe
{
    public int RecipeId  { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public string Url { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients  { get; set; }
}

public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients  { get; set; }
    }

public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public decimal? Amount { get; set; }
        public string Unit { get; set; }
    }