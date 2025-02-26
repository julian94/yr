namespace Yr.Model.Location.Aurora;

public class StatusMessage
{
    /// <summary>
    /// Status as label
    /// </summary>
    [JsonPropertyName("id")]
    public string? ID { get; init; }

    /// <summary>
    /// Status in the specified language
    /// Used for labels
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }
}

/// <summary>
/// Time of day for sunlight.
/// </summary>
public enum SunlightStatus
{
    /// <summary>
    /// In case of unexpected values
    /// </summary>
    Unknown,

    Day,
    Dusk,
    Dawn,
    Night,
}

public class SunlightStatusMessage : StatusMessage
{
    [JsonIgnore]
    public SunlightStatus SunlightStatus => ID switch
    {
        "day" => SunlightStatus.Day,
        "dusk" => SunlightStatus.Dusk,
        "dawn" => SunlightStatus.Dawn,
        "night" => SunlightStatus.Night,
        _ => SunlightStatus.Unknown,
    };
}

/// <summary>
/// How active the aurora is.
/// </summary>
public enum AuroraActivity
{
    /// <summary>
    /// In case of unexpected values
    /// </summary>
    Unknown,

    None,
    Low,
    High,
}

public class AuroraStatusMessage : StatusMessage
{
    [JsonIgnore]
    public AuroraActivity SunlightStatus => ID switch
    {
        "no_activity" => AuroraActivity.None,
        "low_activity" => AuroraActivity.Low,
        "high_activity" => AuroraActivity.High,
        _ => AuroraActivity.Unknown,
    };
}
