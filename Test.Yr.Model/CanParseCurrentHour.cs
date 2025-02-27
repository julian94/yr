using System.Text.Json;
using Yr.Model.Location;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Model;

public class CanParseCurrentHour
{
    private static string Data => File.ReadAllText("./Data/currentHour.json");

    private static CurrentHour CurrentHour => JsonSerializer.Deserialize<CurrentHour>(Data) ?? throw new Exception();

    [Test]
    public void ParsesWithoutThrowing()
    {
        _ = CurrentHour;
    }

    [Test]
    public void StatusInfo()
    {
        var current = CurrentHour;

        Assert.Multiple(() =>
        {
            Assert.That(current.RadarIsDown, Is.EqualTo(false));
            Assert.That(current.Status?.ServiceIsUp, Is.EqualTo(true));
            Assert.That(current.Status?.Code, Is.EqualTo("Ok"));
            Assert.That(current.Links?.Self?.Href, Is.EqualTo("/api/v0/locations/1-92416/forecast/currenthour"));
        });
    }

    [Test]
    public void Weather()
    {
        var current = CurrentHour;

        Assert.Multiple(() =>
        {
            Assert.That(current.SymbolCode?.NextHour, Is.EqualTo(SymbolEnum.cloudy));
            Assert.That(current.Temperature?.Value, Is.EqualTo(5.5));
            Assert.That(current.Temperature?.FeelsLike, Is.EqualTo(3));
            Assert.That(current.Precipitation?.Value, Is.EqualTo(0));
            Assert.That(current.Wind?.Direction, Is.EqualTo(147));
            Assert.That(current.Wind?.Gust, Is.EqualTo(4.9));
            Assert.That(current.Wind?.Speed, Is.EqualTo(2.7));
        });
    }
}
