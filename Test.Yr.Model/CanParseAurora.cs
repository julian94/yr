using System.Text.Json;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Model;

public class CanParseAurora
{
    private static string Data => File.ReadAllText("./Data/aurora.json");

    private static Aurora Aurora => JsonSerializer.Deserialize<Aurora>(Data) ?? throw new Exception();

    [Test]
    public void ParsesWithoutThrowing()
    {
        _ = Aurora;
    }

    [Test]
    public void StatusInfo()
    {
        var aurora = Aurora;

        Assert.Multiple(() =>
        {
            Assert.That(aurora.Status?.ServiceIsUp, Is.EqualTo(true));
            Assert.That(aurora.Status?.Code, Is.EqualTo("Ok"));
            Assert.That(aurora.Links?.Self?.Href, Is.EqualTo("/api/v0/locations/1-92416/auroraforecast"));
            Assert.That(aurora.Updated, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 13, 30, 00, new TimeSpan(1, 0, 0))));
            Assert.That(aurora.Start, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 14, 00, 00, new TimeSpan(1, 0, 0))));
            Assert.That(aurora.End, Is.EqualTo(new DateTimeOffset(2025, 03, 02, 00, 00, 00, new TimeSpan(1, 0, 0))));
        });
    }

    [Test]
    public void Activity()
    {
        var intervals = Aurora.Intervals;

        Assert.That(intervals?.Count, Is.EqualTo(59));

        var first = intervals[0];

        Assert.Multiple(() =>
        {
            Assert.That(first.Start, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 14, 00, 00, new TimeSpan(1, 0, 0))));
            Assert.That(first.End, Is.EqualTo(new DateTimeOffset(2025, 02, 27, 15, 00, 00, new TimeSpan(1, 0, 0))));

            Assert.That(first.KpIndex, Is.EqualTo(6));
            Assert.That(first.Auroravalue, Is.EqualTo(0));

            Assert.That(first.Condition?.ID, Is.EqualTo("no_activity"));
            Assert.That(first.Condition?.Text, Is.EqualTo("Ingen aktivitet"));
            Assert.That(first.Sunlight?.ID, Is.EqualTo("day"));
            Assert.That(first.Sunlight?.Text, Is.EqualTo("dag"));

            Assert.That(first.CloudCover?.Value, Is.EqualTo(88));
            Assert.That(first.CloudCover?.High, Is.EqualTo(62));
            Assert.That(first.CloudCover?.Middle, Is.EqualTo(26));
            Assert.That(first.CloudCover?.Low, Is.EqualTo(65));
            Assert.That(first.CloudCover?.Fog, Is.EqualTo(0));
        });
    }
}
