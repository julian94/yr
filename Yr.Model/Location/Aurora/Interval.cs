namespace Yr.Model.Location.Aurora;

public class Interval
{
    /// <summary>
    /// Forecast starts at
    /// </summary>
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    /// <summary>
    /// Forecast ends at
    /// </summary>
    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    /// <summary>
    /// Planetary K-index ranges from 0 to 9.
    /// </summary>
    /// <see href="https://en.wikipedia.org/wiki/K-index">Wikipedia article</see>
    [JsonPropertyName("kpIndex")]
    public double? KpIndex { get; init; }

    /// <summary>
    /// Seems to range from 0-1, where 0.4+ is high activity.
    /// </summary>
    [JsonPropertyName("auroraValue")]
    public double? Auroravalue { get; init; }

    /// <summary>
    /// If there aurora?
    /// </summary>
    [JsonPropertyName("condition")]
    public AuroraStatusMessage? Condition { get; init; }

    /// <summary>
    /// Is it day/dusk/night/dawn?
    /// </summary>
    [JsonPropertyName("sunlight")]
    public SunlightStatusMessage? Sunlight { get; init; }

    /// <summary>
    /// How much cloud cover is there?
    /// </summary>
    [JsonPropertyName("cloudCover")]
    public CloudCover? CloudCover { get; init; }
}
