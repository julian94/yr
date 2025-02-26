namespace Yr.Model.Map;

public class TileSet
{
    [JsonPropertyName("bounds")]
    public List<double>? Bounds { get; init; }

    [JsonPropertyName("minzoom")]
    public long? Minzoom { get; init; }

    [JsonPropertyName("maxzoom")]
    public long? Maxzoom { get; init; }

    [JsonPropertyName("scheme")]
    public string? Scheme { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("times")]
    public List<Time>? Times { get; init; }
}

public class Time
{
    [JsonPropertyName("time")]
    public DateTimeOffset? TimeTime { get; init; }

    [JsonPropertyName("tiles")]
    public Tiles? Tiles { get; init; }
}

public class Tiles
{
    [JsonPropertyName("png")]
    public string? Png { get; init; }

    [JsonPropertyName("webp")]
    public string? Webp { get; init; }
}

public class RainObservations : TileSet, IRequestable;
public class RainPredictions : TileSet, IRequestable;
public class Wind : TileSet, IRequestable;
