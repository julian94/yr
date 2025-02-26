namespace Yr.Model.Aurora;

public class StatusMessage
{
    [JsonPropertyName("id")]
    public string? ID { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }
}

public enum SunlightStatus
{
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

public enum AuroraStatus
{
    Unknown,
    NoActivity,
    LowActivity,
    HighActivity,
}

public class AuroraStatusMessage : StatusMessage
{
    [JsonIgnore]
    public AuroraStatus SunlightStatus => ID switch
    {
        "no_activity" => AuroraStatus.NoActivity,
        "low_activity" => AuroraStatus.LowActivity,
        "high_activity" => AuroraStatus.HighActivity,
        _ => AuroraStatus.Unknown,
    };
}
