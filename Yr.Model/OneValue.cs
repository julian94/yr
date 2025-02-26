namespace Yr.Model;

public class OneValue
{
    [JsonPropertyName("value")]
    public required double Value { get; init; }
}
