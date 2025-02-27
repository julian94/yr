using Flurl.Http.Testing;
using System.Text.Json;
using Yr.Client;
using Yr.Model.Location.Requestables;

namespace Test.Yr.Client;

public class GetForecast
{
    private static string Data => File.ReadAllText("./Data/forecast.json");

    private static Forecast Forecast { get => JsonSerializer.Deserialize<Forecast>(Data) ?? throw new Exception(); }

    [Test]
    public async Task CanFetch()
    {
        using var httpTest = new HttpTest();

        httpTest.RespondWithJson(Forecast);

        var options = new YrOptions()
        {
            ProgramInfo = new()
            {
                Name = "test",
                Version = "0.0.0",
                ContactPoint = "admin@example.com",
            }
        };

        var location = new LocationID()
        {
            ID = "1-92416"
        };

        var forecast = await location.GetAsync<Forecast>(options);

        httpTest.ShouldHaveCalled("https://www.yr.no/api/v0/locations/1-92416/forecast").Times(1);

        Assert.Multiple(() =>
        {
            Assert.That(forecast.Created, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 13, 27, 46, new TimeSpan(1, 0, 0))));
            Assert.That(forecast.Update, Is.EqualTo(new DateTimeOffset(2025, 02, 26, 14, 27, 46, new TimeSpan(1, 0, 0))));
        });
    }
}
