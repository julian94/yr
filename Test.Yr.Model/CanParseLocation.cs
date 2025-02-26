using System.Text.Json;
using Yr.Model;

namespace Test.Yr.Model;

public class CanParseLocation
{
    private const string Data = """
        {
          "category": {
            "id": "CB09",
            "name": "By"
          },
          "id": "1-92416",
          "name": "Bergen",
          "position": {
            "lat": 60.39323,
            "lon": 5.3245
          },
          "elevation": 6,
          "coastalPoint": {
            "lat": 60.39862,
            "lon": 5.29708
          },
          "timeZone": "Europe/Oslo",
          "urlPath": "Noreg/Vestland/Bergen/Bergen",
          "country": {
            "id": "NO",
            "name": "Noreg"
          },
          "region": {
            "id": "NO/46",
            "name": "Vestland"
          },
          "subregion": {
            "id": "NO/46/4601",
            "name": "Bergen"
          },
          "isInOcean": false,
          "_links": {
            "self": {
              "href": "/api/v0/locations/1-92416"
            },
            "celestialevents": {
              "href": "/api/v0/locations/1-92416/celestialevents"
            },
            "forecast": {
              "href": "/api/v0/locations/1-92416/forecast"
            },
            "cameras": {
              "href": "/api/v0/locations/1-92416/cameras"
            },
            "currenthour": {
              "href": "/api/v0/locations/1-92416/forecast/currenthour"
            },
            "mapfeature": {
              "href": "/api/v0/locations/1-92416/mapfeature"
            },
            "coast": {
              "href": "/api/v0/locations/1-92416/forecast/coast"
            },
            "tide": {
              "href": "/api/v0/locations/1-92416/tide"
            },
            "now": {
              "href": "/api/v0/locations/1-92416/forecast/now"
            },
            "subseasonalforecast": {
              "href": "/api/v0/locations/1-92416/subseasonalforecast"
            },
            "auroraforecast": {
              "href": "/api/v0/locations/1-92416/auroraforecast"
            },
            "notifications": {
              "href": "/api/v0/locations/1-92416/notifications"
            },
            "extremeforecasts": {
              "href": "/api/v0/locations/1-92416/notifications/extreme"
            },
            "warnings": {
              "href": "/api/v0/locations/1-92416/warnings"
            },
            "extremewarnings": {
              "href": "/api/v0/locations/1-92416/warnings/extreme"
            },
            "watertemperatures": {
              "href": "/api/v0/locations/1-92416/nearestwatertemperatures"
            },
            "airqualityforecast": {
              "href": "/api/v0/locations/1-92416/airqualityforecast"
            },
            "pollen": {
              "href": "/api/v0/locations/1-92416/pollen"
            },
            "observations": [
              {
                "href": "/api/v0/locations/1-92416/observations"
              },
              {
                "href": "/api/v0/locations/1-92416/observations/nearby"
              },
              {
                "href": "/api/v0/locations/1-92416/observations/year"
              },
              {
                "href": "/api/v0/locations/1-92416/observations/month"
              },
              {
                "href": "/api/v0/locations/1-92416/observations/day"
              },
              {
                "href": "/api/v0/locations/1-92416/observations/yyyy-MM-dd"
              }
            ]
          }
        }
        """;

    private static Location Location { get => JsonSerializer.Deserialize<Location>(Data) ?? throw new Exception(); }

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
