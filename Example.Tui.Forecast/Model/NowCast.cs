namespace Yr.Example.Tui.Forecast.Model;

public sealed class Rain : IBarChartItem
{
    public required string Label { get; set; }
    public required double Value { get; set; }
    public required Color? Color { get; set; }
}
