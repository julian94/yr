namespace Yr.Client;

public class YrOptions
{
    public LanguageParameter Language { get; init; } = LanguageParameter.English;

    public required ProgramInfo ProgramInfo { get; init; }
}
