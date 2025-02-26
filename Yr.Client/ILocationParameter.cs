using System.Globalization;

namespace Yr.Client;

public interface ILocationParameter
{
    public string Parameter { get; }
}

public class LocationID : ILocationParameter
{
    public required string ID { get; init; }
    public string Parameter => ID;
}

public class CoordinateLocation : ILocationParameter
{
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }

    public string Parameter => string.Create(CultureInfo.InvariantCulture, $"{Latitude:N4},{Longitude:N4}");
}
