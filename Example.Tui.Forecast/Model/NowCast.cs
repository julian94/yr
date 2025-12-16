namespace Yr.Example.Tui.Forecast.Model;

public sealed class RainTimePoint(TimePoint t, Color c) : IBarChartItem
{
    public string Label { get; set; } = t.Time.ToString();
    public double Value { get; set; } = t.Precipitation.Intensity.Value;
    public Color? Color { get; set; } = c;
}
