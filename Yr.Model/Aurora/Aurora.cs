namespace Yr.Model.Aurora;

public class Aurora
{

    [JsonPropertyName("updated")]
    public DateTimeOffset? Updated { get; init; }

    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    [JsonPropertyName("lowValue")]
    public double? Minimum { get; init; }

    [JsonPropertyName("highValue")]
    public double? Maximum { get; init; }

    [JsonPropertyName("shortIntervals")]
    public List<Interval>? Intervals { get; init; }

    [JsonPropertyName("status")]
    public StatusCode? Status { get; init; }
}
