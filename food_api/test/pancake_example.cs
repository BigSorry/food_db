using Data;

    public static class SeedData
    {
        public static Recipe GetPancakeRecipe()
        {
            return new Recipe
            {
                RecipeId = 1,
                Name = "Pancakes",
                Description = "Fluffy pancakes",
                Instructions = "Mix ingredients, cook on a hot griddle."
            };
        }

        public static List<Ingredient> GetPancakeIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient { IngredientId = 1, Name = "Flour" },
                new Ingredient { IngredientId = 2, Name = "Milk" },
                new Ingredient { IngredientId = 3, Name = "Egg" },
                new Ingredient { IngredientId = 4, Name = "Baking Powder" },
                new Ingredient { IngredientId = 5, Name = "Salt" },
                new Ingredient { IngredientId = 6, Name = "Sugar" }
            };
        }

        public static List<RecipeIngredient> GetPancakeRecipeIngredients()
        {
            return new List<RecipeIngredient>
            {
                new RecipeIngredient { RecipeId = 1, IngredientId = 1, Amount = 1.0m, Unit = "cup" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 2, Amount = 1.0m, Unit = "cup" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 3, Amount = 1.0m, Unit = "piece" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 4, Amount = 2.0m, Unit = "tsp" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 5, Amount = 0.5m, Unit = "tsp" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 6, Amount = 2.0m, Unit = "tbsp" }
            };
        }
    }

