using System.Text.Json;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Model;

public class CanParseLocation
{
    private static string Data => File.ReadAllText("./Data/location.json");

    private static LocationData Location => JsonSerializer.Deserialize<LocationData>(Data) ?? throw new Exception();

    [Test]
    public void ParsesWithoutThrowing()
    {
        _ = Location;
    }

    [Test]
    public void LocationInfo()
    {
        var location = Location;

        Assert.Multiple(() =>
        {
            Assert.That(location.Country.ID, Is.EqualTo("NO"));
            Assert.That(location.Country.Name, Is.EqualTo("Noreg"));
            Assert.That(location.Region.ID, Is.EqualTo("NO/46"));
            Assert.That(location.Region.Name, Is.EqualTo("Vestland"));
            Assert.That(location.SubRegion.ID, Is.EqualTo("NO/46/4601"));
            Assert.That(location.SubRegion.Name, Is.EqualTo("Bergen"));
            Assert.That(location.ID, Is.EqualTo("1-92416"));
            Assert.That(location.Name, Is.EqualTo("Bergen"));
            Assert.That(location.Category.ID, Is.EqualTo("CB09"));
            Assert.That(location.Category.Name, Is.EqualTo("By"));
        });
    }

    [Test]
    public void GeographicalInfo()
    {
        var location = Location;

        Assert.Multiple(() =>
        {
            Assert.That(location.Position.Latitude, Is.EqualTo(60.39323));
            Assert.That(location.Position.Longitude, Is.EqualTo(5.3245));
            Assert.That(location.CoastalPoint.Latitude, Is.EqualTo(60.39862));
            Assert.That(location.CoastalPoint.Longitude, Is.EqualTo(5.29708));
            Assert.That(location.Elevation, Is.EqualTo(6));
        });
    }

    [Test]
    public void Timezone()
    {
        var location = Location;

        Assert.Multiple(() =>
        {
            Assert.That(location.TimeZone, Is.EqualTo("Europe/Oslo"));
        });
    }
}
