using ManipuladorData.Data;
using ManipuladorData.Enums;

namespace ManipuladorData.Extensions;

public static class DateTimeExtension
{
    public static DateTime[] ChangeDateRange(this DateTime date, TimeManipulationSpans range)
    {
        return range switch
        {
            TimeManipulationSpans.Hoje => Today(date),
            TimeManipulationSpans.Ontem => Yesterday(date),
            TimeManipulationSpans.EstaSemana => ThisWeek(date),
            TimeManipulationSpans.EsteMes => ThisMonth(date),
            TimeManipulationSpans.Ultimos30Dias => Last30Days(date),
            TimeManipulationSpans.MesAnterior => LastMonth(date),
            TimeManipulationSpans.Ultimos3Meses => LastAmountOfMonths(date, 3),
            TimeManipulationSpans.Ultimos6Meses => LastAmountOfMonths(date, 6),
            _ => throw new ArgumentOutOfRangeException(nameof(range), range, null)
        };
    }

    private static DateTime[] Today(DateTime date)
    {
        return new[] { DateTime.Parse($"{date.ToShortDateString()} 00:00"), DateTime.Parse($"{date.ToShortDateString()} 23:59") };
    }

    private static DateTime[] Yesterday(DateTime date)
    {
        var yesterday = date.AddDays(-1).ToShortDateString();
        return new[] { DateTime.Parse($"{yesterday} 00:00"), DateTime.Parse($"{yesterday} 23:59") };
    }

    private static DateTime[] ThisWeek(DateTime date)
    {
        var weekDay = (int)date.DayOfWeek;
        var weekStart = date.AddDays(-weekDay).ToShortDateString();
        var weekEnd = date.AddDays(6 - weekDay).ToShortDateString();
        return new[] { DateTime.Parse($"{weekStart} 00:00"), DateTime.Parse($"{weekEnd} 23:59") };
    }

    private static DateTime[] ThisMonth(DateTime date)
    {
        var startOfMonth = date.AddDays(-(date.Day - 1)).ToShortDateString();
        var endOfMonth = date.Month == 2 && YearConstants.IsLeapYear(date.Year) ? date.AddDays(29 - date.Day) : date.AddDays(YearConstants.DaysInMonth[date.Month] - date.Day);
        return new[] { DateTime.Parse($"{startOfMonth} 00:00"), DateTime.Parse($"{endOfMonth} 23:59") };
    }

    private static DateTime[] Last30Days(DateTime date)
    {
        return new[] { DateTime.Parse($"{date.AddDays(-30).ToShortDateString()} 00:00"), date };
    }

    private static DateTime[] LastMonth(DateTime date)
    {
        return ThisMonth(date.AddMonths(-1));
    }

    private static DateTime[] LastAmountOfMonths(DateTime date, int amountOfMonths)
    {
        var startingMonth = date.AddMonths(-amountOfMonths);
        var startOfPeriod = startingMonth.AddDays(-(startingMonth.Day - 1));
        var endOfPeriod = date.Month == 2 && YearConstants.IsLeapYear(date.Year) ? date.AddDays(29 - date.Day) : date.AddDays(YearConstants.DaysInMonth[date.Month] - date.Day);
        return new[] { startOfPeriod, endOfPeriod };
    }
}