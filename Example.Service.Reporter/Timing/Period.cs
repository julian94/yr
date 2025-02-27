using System;
using System.Text.RegularExpressions;
using IntOrDouble = (int? i, double? d);

namespace Example.Service.Reporter.Timing;

public partial class Period
{
    // The smallest of these is allowed to be a fraction. The rest must be integers.
    public IntOrDouble Years { get; init; }
    public IntOrDouble Months { get; init; }
    public IntOrDouble Weeks { get; init; }
    public IntOrDouble Days { get; init; }
    public IntOrDouble Hours { get; init; }
    public IntOrDouble Minutes { get; init; }
    public IntOrDouble Seconds { get; init; }


    /// <summary>
    /// Makes a new period from a string.
    /// </summary>
    /// <param name="period">Properly formatted ISO-8601 Period.</param>
    public Period(string period)
    {
        var regex = PeriodRegex();
        var groups = regex.Match(period).Groups;
        Years = groups.GetTuple("years");
        Months = groups.GetTuple("months");
        Weeks = groups.GetTuple("weeks");
        Days = groups.GetTuple("days");
        Hours = groups.GetTuple("hours");
        Minutes = groups.GetTuple("minutes");
        Seconds = groups.GetTuple("seconds");
    }

    public DateTimeOffset AddTime(DateTimeOffset dateTimeOffset) => dateTimeOffset
        .AddYears(Years)
        .AddMonths(Months)
        .AddWeeks(Weeks)
        .AddDays(Days)
        .AddHours(Hours)
        .AddMinutes(Minutes)
        .AddSeconds(Seconds);

    [GeneratedRegex(@"/P(?:(?'year'\d+[\.\,]*\d*)Y)*(?:(?'months'\d+[\.\,]*\d*)M)*(?:(?'weeks'\d+[\.\,]*\d*)W)*(?:(?'days'\d+[\.\,]*\d*)D)*T*(?:(?'hours'\d+[\.\,]*\d*)H)*(?:(?'minutes'\d+[\.\,]*\d*)M)*(?:(?'seconds'\d+[\.\,]*\d*)S)*/gm")]
    private static partial Regex PeriodRegex();
}

file static class PeriodExtensions
{
    public static IntOrDouble GetTuple(this GroupCollection collection, string name)
    {
        if (collection.ContainsKey(name))
        {
            var value = collection[name].Value;
            if (int.TryParse(value, out var intResult)) return (intResult, null);
            else if (double.TryParse(value, out var doubleResult)) return (null, doubleResult);
            else return (null, null);

        }
        else return (null, null);
    }

    public static DateTimeOffset AddPeriod(this DateTimeOffset date, Period period) => period.AddTime(date);

    public static DateTimeOffset AddYears(this DateTimeOffset date, IntOrDouble years)
    {
        if (years.i is int i) return date.AddYears(i);
        else if (years.d is double d)
        {
            var days = date.DaysInYear() / d;
            var seconds = days - Math.Truncate(days);
            return date.AddDays(days);
        }
        else return date;
    }

    public static DateTimeOffset AddMonths(this DateTimeOffset date, IntOrDouble months)
    {
        if (months.i is int i) return date.AddMonths(i);
        else if (months.d is double d)
        {
            var days = date.DaysInMonth() / d;
            return date.AddDays(days);
        }
        else return date;
    }

    public static DateTimeOffset AddWeeks(this DateTimeOffset date, IntOrDouble weeks)
    {
        if (weeks.i is int i) return date.AddDays(7 * i);
        else if (weeks.d is double d) return date.AddDays(7 * d);
        else return date;
    }

    public static DateTimeOffset AddDays(this DateTimeOffset date, IntOrDouble days)
    {
        if (days.i is int i) return date.AddDays(i);
        else if (days.d is double d) return date.AddDays(d);
        else return date;
    }

    public static DateTimeOffset AddHours(this DateTimeOffset date, IntOrDouble hours)
    {
        if (hours.i is int i) return date.AddDays(i);
        else if (hours.d is double d) return date.AddDays(d);
        else return date;
    }

    public static DateTimeOffset AddMinutes(this DateTimeOffset date, IntOrDouble mintues)
    {
        if (mintues.i is int i) return date.AddDays(i);
        else if (mintues.d is double d) return date.AddDays(d);
        else return date;
    }

    public static DateTimeOffset AddSeconds(this DateTimeOffset date, IntOrDouble seconds)
    {
        if (seconds.i is int i) return date.AddDays(i);
        else if (seconds.d is double d) return date.AddDays(d);
        else return date;
    }

    public static int DaysInYear(this DateTimeOffset date) => (date.Year % 400 == 0, date.Year % 100 == 0) switch
    {
        (false, true) => 366,
        (_, _) => 365,
    };

    public static int DaysInMonth(this DateTimeOffset date) => (DaysInYear(date), date.Month) switch
    {
        (_, 1) => 31,
        (365, 2) => 28,
        (366, 2) => 29,
        (_, 3) => 31,
        (_, 4) => 30,
        (_, 5) => 31,
        (_, 6) => 30,
        (_, 7) => 31,
        (_, 8) => 31,
        (_, 9) => 30,
        (_, 10) => 31,
        (_, 11) => 30,
        (_, 12) => 31,
        (_, _) => throw new Exception("This only supports 12 months/year.")
    };
}
