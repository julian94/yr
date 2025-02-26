namespace Yr.Model.Location;

public class DayInterval
{
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset End { get; init; }

    // These strings are enums.
    [JsonPropertyName("twentyFourHourSymbol")]
    public string? TwentyFourHourSymbol { get; init; }

    [JsonPropertyName("twelveHourSymbols")]
    public List<string?>? TwelveHourSymbols { get; init; }

    [JsonPropertyName("sixHourSymbols")]
    public List<string?>? SixHourSymbols { get; init; }

    [JsonPropertyName("symbolConfidence")]
    public string? SymbolConfidence { get; init; }

    [JsonPropertyName("precipitation")]
    public Precipitation? Precipitation { get; init; }

    [JsonPropertyName("temperature")]
    public Temperature? Temperature { get; init; }

    [JsonPropertyName("wind")]
    public Wind? Wind { get; init; }
}

public class LongInterval
{
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("nominalStart")]
    public DateTimeOffset? NominalStart { get; init; }

    [JsonPropertyName("nominalEnd")]
    public DateTimeOffset? NominalEnd { get; init; }

    [JsonPropertyName("symbol")]
    public Symbol? Symbol { get; init; }

    [JsonPropertyName("symbolCode")]
    public SymbolCode? SymbolCode { get; init; }

    [JsonPropertyName("symbolConfidence")]
    public string? SymbolConfidence { get; init; }

    [JsonPropertyName("precipitation")]
    public DetailedPrecipitation? Precipitation { get; init; }

    [JsonPropertyName("temperature")]
    public FullyDetailedTemperature? Temperature { get; init; }

    [JsonPropertyName("wind")]
    public DetailedWind? Wind { get; init; }

    [JsonPropertyName("feelsLike")]
    public OneValue? FeelsLike { get; init; }

    [JsonPropertyName("pressure")]
    public OneValue? Pressure { get; init; }

    [JsonPropertyName("cloudCover")]
    public CloudCover? CloudCover { get; init; }

    [JsonPropertyName("humidity")]
    public OneValue? Humidity { get; init; }

    [JsonPropertyName("dewPoint")]
    public OneValue? DewPoint { get; init; }
}

public class ShortInterval
{
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("symbol")]
    public Symbol? Symbol { get; init; }

    [JsonPropertyName("symbolCode")]
    public SymbolCode? SymbolCode { get; init; }

    [JsonPropertyName("symbolConfidence")]
    public string? SymbolConfidence { get; init; }

    [JsonPropertyName("precipitation")]
    public DetailedPrecipitation? Precipitation { get; init; }

    [JsonPropertyName("temperature")]
    public DetailedTemperature? Temperature { get; init; }

    [JsonPropertyName("wind")]
    public DetailedWind? Wind { get; init; }

    [JsonPropertyName("feelsLike")]
    public OneValue? FeelsLike { get; init; }

    [JsonPropertyName("pressure")]
    public OneValue? Pressure { get; init; }

    [JsonPropertyName("uvIndex")]
    public OneValue? UltraVioletIndex { get; init; }

    [JsonPropertyName("cloudCover")]
    public CloudCover? CloudCover { get; init; }

    [JsonPropertyName("humidity")]
    public OneValue? Humidity { get; init; }

    [JsonPropertyName("dewPoint")]
    public OneValue? DewPoint { get; init; }
}
