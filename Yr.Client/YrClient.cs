using Flurl;
using Flurl.Http;
using Yr.Model;
using Yr.Model.Aurora;

namespace Yr.Client;

public class ProgramInfo
{
    public required string Name { get; init; }
    public required string Version { get; init; }
    public required string ContactPoint { get; init; }

    public override string ToString() => $"{Name}/{Version} - {ContactPoint}";
}

public class YrOptions
{
    public LanguageParameter Language { get; init; } = LanguageParameter.English;

    public required ProgramInfo ProgramInfo { get; init; }
}

public class YrClient(YrOptions options)
{
    public async Task<Location> GetLocation(ILocationParameter location) =>
        await GetAsync<Location>($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}");

    public async Task<Forecast> GetForecast(ILocationParameter location) =>
        await GetAsync<Forecast>($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/forecast");

    public async Task<Aurora> GetAurora(ILocationParameter location) =>
        await GetAsync<Aurora>($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/auroraforecast");

    public async Task<T> GetAsync<T>(string uri) => await uri
        .SetQueryParam("language", options.Language.Code())
        .WithHeader("User-Agent", options.ProgramInfo.ToString())
        .GetJsonAsync<T>();
}
