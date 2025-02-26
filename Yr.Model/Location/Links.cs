namespace Yr.Model.Location;

public class Links
{
    [JsonPropertyName("self")]
    public Link? Self { get; init; }

    [JsonPropertyName("parent")]
    public Link? Parent { get; init; }

    [JsonPropertyName("celestialevents")]
    public Link? Celestialevents { get; init; }

    [JsonPropertyName("forecast")]
    public Link? Forecast { get; init; }

    [JsonPropertyName("cameras")]
    public Link? Cameras { get; init; }

    [JsonPropertyName("currenthour")]
    public Link? Currenthour { get; init; }

    [JsonPropertyName("mapfeature")]
    public Link? Mapfeature { get; init; }

    [JsonPropertyName("coast")]
    public Link? Coast { get; init; }

    [JsonPropertyName("tide")]
    public Link? Tide { get; init; }

    [JsonPropertyName("now")]
    public Link? Now { get; init; }

    [JsonPropertyName("subseasonalforecast")]
    public Link? Subseasonalforecast { get; init; }

    [JsonPropertyName("auroraforecast")]
    public Link? Auroraforecast { get; init; }

    [JsonPropertyName("notifications")]
    public Link? Notifications { get; init; }

    [JsonPropertyName("extremeforecasts")]
    public Link? Extremeforecasts { get; init; }

    [JsonPropertyName("warnings")]
    public Link? Warnings { get; init; }

    [JsonPropertyName("extremewarnings")]
    public Link? Extremewarnings { get; init; }

    [JsonPropertyName("watertemperatures")]
    public Link? Watertemperatures { get; init; }

    [JsonPropertyName("airqualityforecast")]
    public Link? Airqualityforecast { get; init; }

    [JsonPropertyName("pollen")]
    public Link? Pollen { get; init; }

    [JsonPropertyName("observations")]
    public List<Link>? Observations { get; init; }
}

public partial class Link
{
    [JsonPropertyName("href")]
    public required string Href { get; init; }
}