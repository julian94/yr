namespace Yr.Model;

public class CloudCover
{
    [JsonPropertyName("value")]
    public required int Value { get; init; }

    [JsonPropertyName("low")]
    public required int Low { get; init; }

    [JsonPropertyName("middle")]
    public required int Middle { get; init; }

    [JsonPropertyName("high")]
    public required int High { get; init; }

    [JsonPropertyName("fog")]
    public required int Fog { get; init; }
}
