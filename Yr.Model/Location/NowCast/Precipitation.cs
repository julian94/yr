namespace Yr.Model.Location.NowCast;

/// <summary>
/// Time of day for sunlight.
/// </summary>
public enum Phase
{
    /// <summary>
    /// In case of unexpected values
    /// </summary>
    Unknown,

    /// <summary>
    /// Only seen value so far.
    /// </summary>
    None,
}
public class Precipitation
{
    [JsonPropertyName("intensity")]
    public double? Intensity { get; init; }

    [JsonPropertyName("phase")]
    public string? PhaseString { get; init; }

    [JsonIgnore]
    public Phase Phase => PhaseString switch
    {
        "None" => Phase.None,
        _ => Phase.Unknown,
    };
}
