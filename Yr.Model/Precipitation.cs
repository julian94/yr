namespace Yr.Model;

public class Precipitation
{
    [JsonPropertyName("value")]
    public required double Value { get; init; }

    [JsonPropertyName("probability")]
    public required int Probability { get; init; }
}

public class DetailedPrecipitation
{
    [JsonPropertyName("min")]
    public required double Minimum { get; init; }

    [JsonPropertyName("max")]
    public required double Maximum { get; init; }

    [JsonPropertyName("value")]
    public required double Value { get; init; }

    [JsonPropertyName("pop")]
    public required int Pop { get; init; } // The heck is Pop?

    [JsonPropertyName("probability")]
    public required int Probability { get; init; }
}
