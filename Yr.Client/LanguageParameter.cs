namespace Yr.Client;

public enum LanguageParameter
{
    Unset,
    Unknown,
    English,
    NorwegianNynorsk,
    NorwegianBokmål,
    NorthernSami,
}

public static class LanguageExtensions
{
    public static string Parameter(this LanguageParameter language) => language switch
    {
        LanguageParameter.English => "language=en",
        LanguageParameter.NorwegianNynorsk => "language=nn",
        LanguageParameter.NorwegianBokmål => "language=nb",
        LanguageParameter.NorthernSami => "language=sisdoallu",
        _ => string.Empty,
    };

    public static string Code(this LanguageParameter language) => language switch
    {
        LanguageParameter.English => "en",
        LanguageParameter.NorwegianNynorsk => "nn",
        LanguageParameter.NorwegianBokmål => "nb",
        LanguageParameter.NorthernSami => "sisdoallu",
        _ => string.Empty,
    };
}
