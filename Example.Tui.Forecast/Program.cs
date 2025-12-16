YrOptions options = new()
{
    ProgramInfo = new()
    {
        ContactPoint = "https://github.com/julian94/yr",
        Name = "example.tui.forecast",
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
        Forecast 60.39323 5.3245
        Forecast 1-92416
        """),
};

var nowcast = await location.GetAsync<NowCast>(options);
var rainfall = nowcast.Points?.Select(t => new RainTimePoint(t, Color.Blue)).ToList();

AnsiConsole.Write(new BarChart()
    .Width(60)
    .Label("Rain Precipitation")
    .CenterLabel()
    .AddItems(rainfall)
);
