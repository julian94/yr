namespace Yr.Model;

public class Wind
{
    [JsonPropertyName("min")]
    public double? Minimum { get; init; }

    [JsonPropertyName("max")]
    public double? Maximum { get; init; }

    [JsonPropertyName("maxGust")]
    public double? MaximumGust { get; init; }
}

public class DetailedWind
{
    [JsonPropertyName("direction")]
    public int? Direction { get; init; }

    [JsonPropertyName("gust")]
    public double? Gust { get; init; }

    [JsonPropertyName("speed")]
    public double? Speed { get; init; }

    [JsonPropertyName("probability")]
    public DetailedProbability? Probability { get; init; }
}
