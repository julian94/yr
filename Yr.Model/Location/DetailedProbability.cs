namespace Yr.Model.Location;

public class DetailedProbability
{
    [JsonPropertyName("tenPercentile")]
    public double? TenPercentile { get; init; }

    [JsonPropertyName("ninetyPercentile")]
    public double? NinetyPercintile { get; init; }
}
