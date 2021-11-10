namespace Pds.Core.Extensions;

public static class DayOfWeekExtensions
{
    public static string ToShortRussianDayOfWeek(this DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "пн",
            DayOfWeek.Tuesday => "вт",
            DayOfWeek.Wednesday => "ср",
            DayOfWeek.Thursday => "чт",
            DayOfWeek.Friday => "пт",
            DayOfWeek.Saturday => "сб",
            DayOfWeek.Sunday => "вс",
            _ => string.Empty
        };
    }

    public static string ToLongRussianDayOfWeek(this DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => string.Empty
        };
    }
}