using Yr.Model.Location.NowCast;

namespace Yr.Model.Location.Requestables;

public class NowCast : ILocationRequestable
{
    /// <summary>
    /// Forecast should not be update until
    /// </summary>
    [JsonPropertyName("update")]
    public DateTimeOffset? Update { get; init; }

    /// <summary>
    /// Forecast period starts at
    /// </summary>
    [JsonPropertyName("created")]
    public DateTimeOffset? Created { get; init; }
    /// <summary>
    ///  This forecast lasts for
    /// </summary>
    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    /// <summary>
    /// Radar status
    /// </summary>
    [JsonPropertyName("radarIsDown")]
    public bool? RadarIsDown { get; init; }

    /// <summary>
    /// Service status
    /// </summary>
    [JsonPropertyName("status")]
    public StatusCode? Status { get; init; }

    /// <summary>
    /// Forecast points
    /// </summary>
    [JsonPropertyName("points")]
    public List<TimePoint>? Points { get; init; }

    [JsonPropertyName("_links")]
    public Links? Links { get; init; }
}
