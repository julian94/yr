namespace Yr.Model.Location.Requestables;

public interface ISearchable : IRequestable;

public class Suggest : Search;

public class Search : ISearchable
{
    [JsonPropertyName("_links")]
    public Links? Links { get; init; }


    [JsonPropertyName("_embedded")]
    public Embedded? Embedded { get; init; }

    [JsonIgnore]
    public List<LocationData>? Locations => Embedded?.Locations;
}

public class Embedded
{
    [JsonPropertyName("location")]
    public List<LocationData>? Locations { get; init; }
}
