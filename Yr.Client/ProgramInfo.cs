namespace Yr.Client;

public class ProgramInfo
{
    public required string Name { get; init; }
    public required string Version { get; init; }
    public required string ContactPoint { get; init; }

    public override string ToString() => $"{Name}/{Version} - {ContactPoint}";
}
