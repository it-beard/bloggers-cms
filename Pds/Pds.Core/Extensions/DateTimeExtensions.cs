namespace Pds.Core.Extensions;

public static class DateTimeExtensions
{
    public static string ToShortStringDateWithDay(this DateTime date)
    {
        return $"{date:dd.MM} / {date.Date.DayOfWeek.ToShortRussianDayOfWeek()}";
    }

    public static string ToShortStringDate(this DateTime date)
    {
        return $"{date:dd.MM}";
    }

    public static string ToLongStringDateWithDay(this DateTime date)
    {
        return $"{date:d MMMM yyyy} г. ({date.Date.DayOfWeek.ToLongRussianDayOfWeek().ToLower()})";
    }

    public static string ToLongStringDate(this DateTime date)
    {
        return $"{date:d MMMM yyyy} г.";
    }
}