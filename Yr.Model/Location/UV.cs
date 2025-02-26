namespace Yr.Model.Location;

public class UV
{
    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("displayUrl")]
    public string? DisplayUrl { get; init; }
}

