namespace Yr.Model;

public class Duration
{
    [JsonPropertyName("days")]
    public int? Days { get; init; }

    [JsonPropertyName("hours")]
    public int? Hours { get; init; }
}
