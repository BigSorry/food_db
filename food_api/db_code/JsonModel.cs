namespace Data;
public class JsonRecipe
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> Method { get; set; }
}