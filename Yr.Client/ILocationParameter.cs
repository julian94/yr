using System.Globalization;

namespace Yr.Client;

public interface ILocationParameter
{
    public string Parameter { get; }
}

public class LocationID : ILocationParameter
{
    public string ID { get; init; }
    public string Parameter { get => ID; }
}

public class CoordinateLocation : ILocationParameter
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public string Parameter { get => string.Create(CultureInfo.InvariantCulture, $"{Latitude:N4},{Longitude:N4}"); }
}
