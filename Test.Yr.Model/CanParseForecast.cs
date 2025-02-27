using System.Text.Json;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Model;

public class CanParseForecast
{
    private static string Data => File.ReadAllText("./Data/forecast.json");

    private static Forecast Forecast => JsonSerializer.Deserialize<Forecast>(Data) ?? throw new Exception();

    [Test]
    public void ParsesWithoutThrowing()
    {
        _ = Forecast;
    }

    [Test]
    public void Times()
    {
        var forecast = Forecast;

        Assert.Multiple(() =>
        {
            Assert.That(forecast.Created, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 13, 27, 46, new TimeSpan(1, 0, 0))));
            Assert.That(forecast.Update, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 14, 27, 46, new TimeSpan(1, 0, 0))));
        });
    }

    [Test]
    public void Uv()
    {
        var uv = Forecast.UV;

        Assert.Multiple(() =>
        {
            Assert.That(uv?.Url, Is.EqualTo("https://dsa.no/sol-og-solarium/slik-beskytter-du-deg-i-sola"));
            Assert.That(uv?.DisplayUrl, Is.EqualTo("dsa.no"));
            Assert.That(uv?.Duration?.Days, Is.EqualTo(2));
            Assert.That(uv?.Duration?.Hours, Is.EqualTo(5));
        });
    }

    [Test]
    public void DayIntervals()
    {
        var intervals = Forecast.DayIntervals;

        Assert.That(intervals?.Count, Is.EqualTo(10));

        var first = intervals[0];

        Assert.Multiple(() =>
        {
            Assert.That(first.Start, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 13, 00, 00, new TimeSpan(1, 0, 0))));
            Assert.That(first.End, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 23, 00, 00, new TimeSpan(1, 0, 0))));

            Assert.That(first.SymbolConfidence, Is.EqualTo("Certain"));
            Assert.That(first.TwentyFourHourSymbol, Is.EqualTo("rain"));

            Assert.That(first.TwelveHourSymbols?.Count, Is.EqualTo(2));
            Assert.That(first.TwelveHourSymbols?[0], Is.EqualTo(null));
            Assert.That(first.TwelveHourSymbols?[1], Is.EqualTo("lightrain"));

            Assert.That(first.SixHourSymbols?.Count, Is.EqualTo(4));
            Assert.That(first.SixHourSymbols?[0], Is.EqualTo(null));
            Assert.That(first.SixHourSymbols?[1], Is.EqualTo(null));
            Assert.That(first.SixHourSymbols?[2], Is.EqualTo("rain"));
            Assert.That(first.SixHourSymbols?[3], Is.EqualTo("lightrain"));


            Assert.That(first.Precipitation?.Value, Is.EqualTo(2));
            Assert.That(first.Precipitation?.Probability, Is.EqualTo(80));

            Assert.That(first.Temperature?.Value, Is.EqualTo(7.2));
            Assert.That(first.Temperature?.Minimum, Is.EqualTo(4.3));
            Assert.That(first.Temperature?.Maximum, Is.EqualTo(7.2));

            Assert.That(first.Wind?.Minimum, Is.EqualTo(2.2));
            Assert.That(first.Wind?.Maximum, Is.EqualTo(4.2));
            Assert.That(first.Wind?.MaximumGust, Is.EqualTo(7.8));
        });
    }

    [Test]
    public void LongIntervals()
    {
        var intervals = Forecast.LongIntervals;

        Assert.That(intervals?.Count, Is.EqualTo(40));

        var first = intervals[0];

        Assert.Multiple(() =>
        {
            Assert.That(first.Start, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 14, 00, 00, new TimeSpan(1, 0, 0))));
            Assert.That(first.End, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 18, 00, 00, new TimeSpan(1, 0, 0))));
        });
    }

    [Test]
    public void ShortIntervals()
    {
        var intervals = Forecast.ShortIntervals;

        Assert.That(intervals?.Count, Is.EqualTo(53));

        var first = intervals[0];

        Assert.Multiple(() =>
        {
            Assert.That(first.Start, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 14, 00, 00, new TimeSpan(1, 0, 0))));
            Assert.That(first.End, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 15, 00, 00, new TimeSpan(1, 0, 0))));
        });
    }
}
