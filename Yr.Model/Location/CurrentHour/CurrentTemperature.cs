namespace Yr.Model.Location.CurrentHour;

public class CurrentTemperature
{
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonPropertyName("feelsLike")]
    public double? FeelsLike { get; init; }
}
