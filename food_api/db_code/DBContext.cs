using Microsoft.EntityFrameworkCore;
namespace Data;

public class RecipesContext : DbContext
{
    static readonly string connectionString = "Server=localhost;Database=food_recipes;"+
    "User=root;Password=K4a3l21b5u.V2.;";
    
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    } 

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Recipe name must be unique
         modelBuilder.Entity<Recipe>()
        .HasIndex(r => r.Name)
        .IsUnique();
        CreateTablesProperties(modelBuilder);
    }

    private void CreateTablesProperties(ModelBuilder modelBuilder){
        // Configure the primary keys
        modelBuilder.Entity<Recipe>().HasKey(r => r.RecipeId);
        modelBuilder.Entity<Ingredient>().HasKey(i => i.IngredientId);
        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        // Configure the relationships
        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);
    }
}