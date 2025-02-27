using System.Text.Json;
using Yr.Model.Location.NowCast;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Model;

public class CanParseNowCast
{
    private static string Data => File.ReadAllText("./Data/nowCast.json");

    private static NowCast NowCast => JsonSerializer.Deserialize<NowCast>(Data) ?? throw new Exception();

    [Test]
    public void ParsesWithoutThrowing()
    {
        _ = NowCast;
    }

    [Test]
    public void StatusInfo()
    {
        var now = NowCast;

        Assert.Multiple(() =>
        {
            Assert.That(now.RadarIsDown, Is.EqualTo(false));
            Assert.That(now.Status?.ServiceIsUp, Is.EqualTo(true));
            Assert.That(now.Status?.Code, Is.EqualTo("Ok"));
            Assert.That(now.Links?.Self?.Href, Is.EqualTo("/api/v0/locations/1-181828/forecast/now"));
            Assert.That(now.Update, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 14, 47, 18, new TimeSpan(1, 0, 0))));
            Assert.That(now.Created, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 14, 42, 18, new TimeSpan(1, 0, 0))));
        });
    }

    [Test]
    public void Activity()
    {
        var points = NowCast.Points;

        Assert.That(points?.Count, Is.EqualTo(19));

        var second = points[1];

        Assert.Multiple(() =>
        {
            Assert.That(second.Time, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 14, 50, 00, new TimeSpan(1, 0, 0))));

            Assert.That(second.Precipitation?.Intensity, Is.EqualTo(0.9));
            Assert.That(second.Precipitation?.PhaseString, Is.EqualTo("None"));
            Assert.That(second.Precipitation?.Phase, Is.EqualTo(Phase.None));
        });
    }
}
