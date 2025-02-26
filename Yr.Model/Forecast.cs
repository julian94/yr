namespace Yr.Model;

public class Forecast
{
    [JsonPropertyName("created")]
    public DateTimeOffset? Created { get; set; }

    [JsonPropertyName("update")]
    public DateTimeOffset? Update { get; set; }

    [JsonPropertyName("dayIntervals")]
    public List<DayInterval>? DayIntervals { get; set; }

    [JsonPropertyName("longIntervals")]
    public List<LongInterval>? LongIntervals { get; set; }

    [JsonPropertyName("shortIntervals")]
    public List<ShortInterval>? ShortIntervals { get; set; }

    [JsonPropertyName("_links")]
    public Links? Links { get; init; }

    [JsonPropertyName("uv")]
    public UV? UV { get; init; }
}
