namespace Yr.Model.Location.Position;

public class Category
{
    [JsonPropertyName("id")]
    public string? ID { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
