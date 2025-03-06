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

var query = args switch
{
    [string q] => q,
    [] => throw new Exception("You need to specify a location."),
    _ => string.Join(' ', args),
};

Console.WriteLine($"Searching for: {query}");

var result = await query.SearchAsync<Search>(options);

var locations = result.Locations;
if (locations == null || locations.Count == 0)
{
    Console.WriteLine("Unable to find anything with that name.");
}
else
{
    foreach (var location in locations)
    {
        Console.WriteLine($"{location.ID,12}: {location.Category?.Name} in {location.UrlPath}");
    }
}
