using System;

namespace Example.Service.Reporter.Timing;

public enum IntervalType
{
    StartAndEnd,
    StartAndDuration,
    PeriodAndEnd,
    DurationOnly,
    InstantOnly,
}

public interface IInterval
{
    public IntervalType IntervalType { get; }

    public Recurrance? Recurrances { get; }

    public DateTimeOffset? Next(DateTimeOffset date);
}

public class Recurrance
{
    public int? Count { get; init; }
}

public class StartAndPeriodInterval(DateTimeOffset start, Period period, Recurrance? recurrances) : IInterval
{
    public IntervalType IntervalType => IntervalType.StartAndDuration;

    public Recurrance? Recurrances => recurrances;

    public DateTimeOffset? Next(DateTimeOffset date)
    {
        if (date > start) return start;
        else if (recurrances == null)
        {
            var next = period.AddTime(start);
            if (date < next) return next;
            else return null;
        }
        else if (recurrances is Recurrance r && r.Count is null)
        {
            var next = period.AddTime(start);
            while (next < date)
            {
                next = period.AddTime(next);
            }
            return next;
        }
        else
        {
            var next = start;
            for (var i = 0; i < recurrances.Count; i++)
            {
                next = period.AddTime(next);
                if (date < next) return next;
            }
            return null;
        }
    }
}

public class StartAndEndInterval(DateTimeOffset start, DateTimeOffset end, Recurrance? recurrances) : IInterval
{
    public IntervalType IntervalType => IntervalType.StartAndEnd;

    public Recurrance? Recurrances => recurrances;

    public DateTimeOffset? Next(DateTimeOffset date)
    {
        if (date > start) return start;
        else if (date < end) return end;
        else if (Recurrances is Recurrance r && r.Count is null)
        {
            var timespan = end - start;
            var next = end + timespan;
            while (next < date)
            {
                next += timespan;
            }
            return next;
        }
        else
        {
            var timespan = end - start;
            var next = end + timespan;
            for (var i = 0; i < Recurrances?.Count; i++)
            {
                next += timespan;
                if (date < next) return next;
            }
            return null;
        }
    }
}

public class PeriodAndEndInterval(Period period, DateTimeOffset end, Recurrance? recurrances) : IInterval
{
    public IntervalType IntervalType => IntervalType.PeriodAndEnd;

    public Recurrance? Recurrances => recurrances;

    public DateTimeOffset? Next(DateTimeOffset date)
    {
        throw new NotImplementedException();
    }
}

public class PeriodOnlyInterval(Period period, Recurrance? recurrances) : IInterval
{
    public IntervalType IntervalType => IntervalType.PeriodAndEnd;

    public Recurrance? Recurrances => recurrances;

    public DateTimeOffset? Next(DateTimeOffset date)
    {
        throw new NotImplementedException();
    }
}

public class InstantInterval(DateTimeOffset instant) : IInterval
{
    public IntervalType IntervalType => IntervalType.InstantOnly;

    public Recurrance? Recurrances => null;

    public DateTimeOffset? Next(DateTimeOffset date) => (date < instant) ? instant : null;
}