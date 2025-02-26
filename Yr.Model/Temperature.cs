namespace Yr.Model;

public class Temperature
{
    [JsonPropertyName("min")]
    public double? Minimum { get; init; }

    [JsonPropertyName("max")]
    public double? Maximum { get; init; }

    [JsonPropertyName("value")]
    public double? Value { get; init; }
}

public class DetailedTemperature
{
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonPropertyName("probability")]
    public DetailedProbability? Probability { get; init; }
}

public class FullyDetailedTemperature
{
    [JsonPropertyName("min")]
    public double? Minimum { get; init; }

    [JsonPropertyName("max")]
    public double? Maximum { get; init; }

    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonPropertyName("probability")]
    public DetailedProbability? Probability { get; init; }
}
