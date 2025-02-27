using Yr.Model.Location.CurrentHour;

namespace Yr.Model.Location.Requestables;

public class CurrentHour : ILocationRequestable
{
    /// <summary>
    /// Forecast period starts at
    /// </summary>
    [JsonPropertyName("created")]
    public DateTimeOffset? Created { get; init; }

    /// <summary>
    /// Radar status
    /// </summary>
    [JsonPropertyName("radarIsDown")]
    public bool? RadarIsDown { get; init; }

    /// <summary>
    /// Symbol Code
    /// </summary>
    [JsonPropertyName("symbolCode")]
    public SymbolCode? SymbolCode { get; init; }

    [JsonPropertyName("temperature")]
    public CurrentTemperature? Temperature { get; init; }

    [JsonPropertyName("precipitation")]
    public OneValue? Precipitation { get; init; }

    [JsonPropertyName("wind")]
    public DetailedWind? Wind { get; init; }

    /// <summary>
    /// Service status
    /// </summary>
    [JsonPropertyName("status")]
    public StatusCode? Status { get; init; }

    [JsonPropertyName("_links")]
    public Links? Links { get; init; }
}
