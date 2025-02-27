namespace Yr.Model.Location.NowCast;

public class TimePoint
{
    [JsonPropertyName("precipitation")]
    public Precipitation? Precipitation { get; init; }

    [JsonPropertyName("time")]
    public DateTimeOffset? Time { get; init; }

}
