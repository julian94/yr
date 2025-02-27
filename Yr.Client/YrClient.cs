using Flurl;
using Flurl.Http;
using Yr.Model;
using Yr.Model.Location.Requestables;
using Yr.Model.Map;

namespace Yr.Client;


public static class YrClient
{
    public static Uri GetLocationUri<T>(this ILocationParameter location) where T : ILocationRequestable =>
        typeof(T).Name switch
        {
            nameof(LocationData) => new($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}"),
            nameof(Forecast) => new($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/forecast"),
            nameof(Aurora) => new($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/auroraforecast"),
            nameof(NowCast) => new($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/now"),
            nameof(CurrentHour) => new($"{RouteConstants.BasePath}/api/v0/locations/{location.Parameter}/currenthour"),
            _ => throw new Exception("Unsupported request.")
        };

    public static Uri GetGlobalUri<T>() where T : IRequestable =>
        typeof(T).Name switch
        {
            nameof(RainObservations) => new($"{RouteConstants.TileBasePath}/api/precipitation-observations/available.json"),
            nameof(RainPredictions) => new($"{RouteConstants.TileBasePath}/api/precipitation-nowcast/available.json"),
            nameof(Wind) => new($"{RouteConstants.TileBasePath}/api/wind/available.json"),
            _ => throw new Exception("Unsupported request.")
        };

    /// <summary>
    /// Fetch location based weather data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="location"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static Task<T> GetAsync<T>(this ILocationParameter location, YrOptions options) where T : ILocationRequestable =>
        location
            .GetLocationUri<T>()
            .GetAsync<T>(options);

    public static Task<T> GetAsync<T>(YrOptions options) where T : IRequestable =>
        GetGlobalUri<T>()
            .ToFlurlRequest()
            .WithApiHeader()
            .WithLanguage(options.Language)
            .WithProgramInfo(options.ProgramInfo)
            .GetJsonAsync<T>();

    public static Task<T> GetAsync<T>(this Uri uri, YrOptions options) where T : IRequestable =>
        uri
            .ToFlurlRequest()
            .WithApiHeader()
            .WithLanguage(options.Language)
            .WithProgramInfo(options.ProgramInfo)
            .GetJsonAsync<T>();

    /// <summary>
    /// Converts uri to flurlrequest.
    /// </summary>
    /// <param name="uri">Uri to be requested.</param>
    /// <returns></returns>
    private static FlurlRequest ToFlurlRequest(this Uri uri) => new(uri);

    /// <summary>
    /// Sets optional header to specify that this api library is being used.
    /// </summary>
    /// <param name="obj">Object containing request headers.</param>
    /// <returns></returns>
    private static IFlurlRequest WithApiHeader(this IFlurlRequest obj) =>
        obj.WithHeader("x-api-client", "yr-api/0.0.1 - https://github.com/julian94/yr");

    /// <summary>
    /// Sets mandatory header to specify program and contact information.
    /// </summary>
    /// <param name="obj">Object containing request headers.</param>
    /// <param name="info">Information about the client.</param>
    /// <returns></returns>
    private static IFlurlRequest WithProgramInfo(this IFlurlRequest obj, ProgramInfo info) =>
        obj.WithHeader("User-Agent", info.ToString());

    /// <summary>
    /// Sets optional language parameter.
    /// </summary>
    /// <param name="obj">Object containing request headers.</param>
    /// <param name="language">The language you want the response in.</param>
    /// <returns></returns>
    private static IFlurlRequest WithLanguage(this IFlurlRequest obj, LanguageParameter language) =>
        (language == LanguageParameter.Unknown || language == LanguageParameter.Unset)
        ? obj
        : obj.SetQueryParam("language", language.Code());
}
