namespace Yr.Model.Location;

public class StatusCode
{
    /// <summary>
    /// Status code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonIgnore]
    public bool ServiceIsUp => Code == "OK";
}
