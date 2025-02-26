namespace Yr.Model.Aurora;

public class Interval
{
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("kpIndex")]
    public double? KpIndex { get; init; }

    [JsonPropertyName("auroravalue")]
    public double? Auroravalue { get; init; }

    [JsonPropertyName("condition")]
    public AuroraStatusMessage? Condition { get; init; }

    [JsonPropertyName("sunlight")]
    public SunlightStatusMessage? Sunlight { get; init; }

    [JsonPropertyName("cloudCover")]
    public CloudCover? CloudCover { get; init; }
}
