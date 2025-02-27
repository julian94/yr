using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Example.Service.Reporter;

public class Webhook
{
    public required Uri Uri { get; init; }
    public Dictionary<string, string>? Headers { get; init; }
    public string HttpMethod { get; init; }

    public async Task SendMessage(string message) => throw new NotImplementedException();
}
