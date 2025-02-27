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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SymbolEnum? NextHour { get; init; }

    [JsonPropertyName("next6Hours")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SymbolEnum? NextSixHours { get; init; }

    [JsonPropertyName("next12Hours")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SymbolEnum? NextTwelveHours { get; init; }
}

/// <summary>
/// Enum containing all known symbols.
/// Taken directly from: https://api.met.no/weatherapi/nowcast/2.0/swagger
/// </summary>
public enum SymbolEnum
{
    clearsky_day,
    clearsky_night,
    clearsky_polartwilight,
    fair_day,
    fair_night,
    fair_polartwilight,
    lightssnowshowersandthunder_day,
    lightssnowshowersandthunder_night,
    lightssnowshowersandthunder_polartwilight,
    lightsnowshowers_day,
    lightsnowshowers_night,
    lightsnowshowers_polartwilight,
    heavyrainandthunder,
    heavysnowandthunder,
    rainandthunder,
    heavysleetshowersandthunder_day,
    heavysleetshowersandthunder_night,
    heavysleetshowersandthunder_polartwilight,
    heavysnow,
    heavyrainshowers_day,
    heavyrainshowers_night,
    heavyrainshowers_polartwilight,
    lightsleet,
    heavyrain,
    lightrainshowers_day,
    lightrainshowers_night,
    lightrainshowers_polartwilight,
    heavysleetshowers_day,
    heavysleetshowers_night,
    heavysleetshowers_polartwilight,
    lightsleetshowers_day,
    lightsleetshowers_night,
    lightsleetshowers_polartwilight,
    snow,
    heavyrainshowersandthunder_day,
    heavyrainshowersandthunder_night,
    heavyrainshowersandthunder_polartwilight,
    snowshowers_day,
    snowshowers_night,
    snowshowers_polartwilight,
    fog,
    snowshowersandthunder_day,
    snowshowersandthunder_night,
    snowshowersandthunder_polartwilight,
    lightsnowandthunder,
    heavysleetandthunder,
    lightrain,
    rainshowersandthunder_day,
    rainshowersandthunder_night,
    rainshowersandthunder_polartwilight,
    rain,
    lightsnow,
    lightrainshowersandthunder_day,
    lightrainshowersandthunder_night,
    lightrainshowersandthunder_polartwilight,
    heavysleet,
    sleetandthunder,
    lightrainandthunder,
    sleet,
    lightssleetshowersandthunder_day,
    lightssleetshowersandthunder_night,
    lightssleetshowersandthunder_polartwilight,
    lightsleetandthunder,
    partlycloudy_day,
    partlycloudy_night,
    partlycloudy_polartwilight,
    sleetshowersandthunder_day,
    sleetshowersandthunder_night,
    sleetshowersandthunder_polartwilight,
    rainshowers_day,
    rainshowers_night,
    rainshowers_polartwilight,
    snowandthunder,
    sleetshowers_day,
    sleetshowers_night,
    sleetshowers_polartwilight,
    cloudy,
    heavysnowshowersandthunder_day,
    heavysnowshowersandthunder_night,
    heavysnowshowersandthunder_polartwilight,
    heavysnowshowers_day,
    heavysnowshowers_night,
    heavysnowshowers_polartwilight,
}
