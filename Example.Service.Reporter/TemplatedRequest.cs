using System.Threading.Tasks;
using Yr.Client;
using Yr.Model.Location.Requestables;

namespace Example.Service.Reporter;

public class TemplatedRequest(string template, ILocationParameter locationParameter)
{
    public async Task<string> FillTemplate(YrOptions yrOptions)
    {
        LocationData location = await locationParameter.GetAsync<LocationData>(yrOptions);
        Forecast forecast = await locationParameter.GetAsync<Forecast>(yrOptions);

        var result = string.Format(template, location, forecast);
        return result;
    }
}
