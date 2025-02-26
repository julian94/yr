namespace Yr.Model.Location;

public class Symbol
{
    [JsonPropertyName("sunup")]
    public bool? SunIsUp { get; init; }

    [JsonPropertyName("n")]
    public int? N { get; init; } // What does N mean?

    [JsonPropertyName("clouds")]
    public int? Clouds { get; init; }

    [JsonPropertyName("precip")]
    public int? Precipitation { get; init; }

    [JsonPropertyName("var")]
    public string? Var { get; init; } // Sun and Moon are possibilities at least.
}

public class SymbolCode
{
    [JsonPropertyName("next1Hour")]
    public string? NextHour { get; init; }

    [JsonPropertyName("next6Hours")]
    public string? NextSixHours { get; init; }

    [JsonPropertyName("next12Hours")]
    public string? NextTwelveHours { get; init; }
}
