﻿namespace Yr.Model.Location.Position;

public class Coordinates
{
    [JsonPropertyName("lat")]
    public double? Latitude { get; init; }

    [JsonPropertyName("lon")]
    public double? Longitude { get; init; }
}
