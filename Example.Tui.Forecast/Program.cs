using System.Globalization;
using Yr.Client;
using Yr.Model.Location.Requestables;

YrOptions options = new()
{
    ProgramInfo = new()
    {
        ContactPoint = "https://github.com/julian94/yr",
        Name = "example.cli.quickforecast",
        Version = "0.0.1",
    },
    Language = LanguageParameter.English,
};

ILocationParameter location = args switch
{
    [var id] => new LocationID()
    {
        ID = id,
    },
    [var lat, var lon] => new CoordinateLocation()
    {
        Latitude = double.Parse(lat, CultureInfo.InvariantCulture),
        Longitude = double.Parse(lon, CultureInfo.InvariantCulture),
    },
    _ => throw new Exception(
        """
        Please specify a location using either lat/lon or yr location code. Examples:
        QuickForecast 60.39323 5.3245
        QuickForecast 1-92416
        """),
};

var forecast = await location.GetAsync<Forecast>(options);
var next = forecast?.ShortIntervals?[0] ?? throw new Exception("Weather report is busted, please report this on github if problem persists.");

Console.WriteLine(
$"""
The Weather for the next hour will be {next.SymbolCode?.NextHour}
{next.Temperature?.Value:N1}°C  {next.Wind?.Speed:N1}m/s {next.Wind?.CompassDirection}
with {next.Precipitation?.Minimum:N1}-{next.Precipitation?.Maximum:N1}mm of precipitation
""");
