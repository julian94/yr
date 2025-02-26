namespace Yr.Model;

public class Position
{
    [JsonPropertyName("lat")]
    public required double Latitude { get; init; }

    [JsonPropertyName("lon")]
    public required double Longitude { get; init; }
}

public class Category
{
    [JsonPropertyName("id")]
    public required string ID { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

public class Region
{
    [JsonPropertyName("id")]
    public required string ID { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
