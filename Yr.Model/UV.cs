namespace Yr.Model;

public class UV
{
    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("displayUrl")]
    public string? DisplayUrl { get; init; }
}

public class Duration
{
    [JsonPropertyName("days")]
    public int? Days { get; init; }

    [JsonPropertyName("hours")]
    public int? Hours { get; init; }
}
