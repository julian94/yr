namespace Yr.Model;

public class Precipitation
{
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonPropertyName("probability")]
    public int? Probability { get; init; }
}

public class DetailedPrecipitation
{
    [JsonPropertyName("min")]
    public double? Minimum { get; init; }

    [JsonPropertyName("max")]
    public double? Maximum { get; init; }

    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonPropertyName("pop")]
    public int? Pop { get; init; } // The heck is Pop?

    [JsonPropertyName("probability")]
    public int? Probability { get; init; }
}
