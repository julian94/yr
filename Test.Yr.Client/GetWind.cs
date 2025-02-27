using Flurl.Http.Testing;
using System.Text.Json;
using Yr.Client;
using Yr.Model.Map;

namespace Test.Yr.Client;

public class GetWind
{
    private static string Data => File.ReadAllText("./Data/wind.json");

    private static Wind Forecast { get => JsonSerializer.Deserialize<Wind>(Data) ?? throw new Exception(); }

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

        var wind = await YrClient.GetAsync<Wind>(options);

        httpTest.ShouldHaveCalled("https://tiles.yr.no/api/wind/available.json").Times(1);

        Assert.Multiple(() =>
        {
            Assert.That(wind.Name, Is.EqualTo("wind"));
            Assert.That(wind.Scheme, Is.EqualTo("xyz"));
            Assert.That(wind.Minzoom, Is.EqualTo(0));
            Assert.That(wind.Maxzoom, Is.EqualTo(6));
        });
    }
}
