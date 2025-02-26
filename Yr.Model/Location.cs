namespace Yr.Model;

public class Location
{

    [JsonPropertyName("category")]
    public required Category Category { get; init; }

    [JsonPropertyName("id")]
    public required string ID { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("position")]
    public required Position Position { get; init; }

    [JsonPropertyName("coastalPoint")]
    public required Position CoastalPoint { get; init; }

    [JsonPropertyName("elevation")]
    public required int Elevation { get; init; }

    [JsonPropertyName("timeZone")]
    public required string TimeZone { get; init; }

    [JsonPropertyName("urlPath")]
    public required string UrlPath { get; init; }

    [JsonPropertyName("country")]
    public required Region Country { get; init; }

    [JsonPropertyName("region")]
    public required Region Region { get; init; }

    [JsonPropertyName("subregion")]
    public required Region SubRegion { get; init; }

    [JsonPropertyName("isInOcean")]
    public required bool IsInOcean { get; init; }

    [JsonPropertyName("_links")]
    public required Links Links { get; init; }
}
