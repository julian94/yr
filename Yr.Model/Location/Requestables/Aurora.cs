using Yr.Model.Location.Aurora;

namespace Yr.Model.Location.Requestables;

public class Aurora : ILocationRequestable
{

    /// <summary>
    /// Forecast was updated at
    /// </summary>
    [JsonPropertyName("updated")]
    public DateTimeOffset? Updated { get; init; }

    /// <summary>
    /// Forecast period starts at
    /// </summary>
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    /// <summary>
    /// Forecast period ends at
    /// </summary>
    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    /// <summary>
    ///  This forecast lasts for
    /// </summary>
    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    /// <summary>
    /// Aurora Minimum
    /// </summary>
    [JsonPropertyName("lowValue")]
    public double? Minimum { get; init; }

    /// <summary>
    /// Aurora Maximum
    /// </summary>
    [JsonPropertyName("highValue")]
    public double? Maximum { get; init; }

    /// <summary>
    /// Forecast intervals
    /// </summary>
    [JsonPropertyName("shortIntervals")]
    public List<Interval>? Intervals { get; init; }

    /// <summary>
    /// Status of the forecast service.
    /// </summary>
    [JsonPropertyName("status")]
    public StatusCode? Status { get; init; }

    [JsonPropertyName("_links")]
    public Links? Links { get; init; }
}
