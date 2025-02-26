using Yr.Model.Position;

namespace Yr.Model;

public class Location
{

    [JsonPropertyName("category")]
    public Category? Category { get; init; }

    [JsonPropertyName("id")]
    public string? ID { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("position")]
    public Position? Position { get; init; }

    [JsonPropertyName("coastalPoint")]
    public Position? CoastalPoint { get; init; }

    [JsonPropertyName("elevation")]
    public int? Elevation { get; init; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; init; }

    [JsonPropertyName("urlPath")]
    public string? UrlPath { get; init; }

    [JsonPropertyName("country")]
    public Region? Country { get; init; }

    [JsonPropertyName("region")]
    public Region? Region { get; init; }

    [JsonPropertyName("subregion")]
    public Region? SubRegion { get; init; }

    [JsonPropertyName("isInOcean")]
    public bool? IsInOcean { get; init; }

    [JsonPropertyName("_links")]
    public Links? Links { get; init; }
}
