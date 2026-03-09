namespace WeddingWebsite.Core;

public static class DateTimeExtensions
{
    /// <summary>
    /// E.g. "2 days", "3 hours", "5 minutes", "1 month", "2 weeks"
    /// Should only be treated as an approximate value.
    /// </summary>
    public static string FormatShortDuration(this TimeSpan span)
    {
        if (span.TotalDays >= 30)
        {
            var months = (int)(span.TotalDays / 30);
            return months == 1 ? "1 month" : $"{months} months";
        }
        if (span.TotalDays >= 7)
        {
            var weeks = (int)(span.TotalDays / 7);
            return weeks == 1 ? "1 week" : $"{weeks} weeks";
        }
        if (span.TotalDays >= 1)
        {
            var days = (int)span.TotalDays;
            return days == 1 ? "1 day" : $"{days} days";
        }
        if (span.TotalHours >= 1)
        {
            var hours = (int)span.TotalHours;
            return hours == 1 ? "1 hour" : $"{hours} hours";
        }
        var minutes = (int)span.TotalMinutes;
        return minutes <= 1 ? "1 minute" : $"{minutes} minutes";
    }
    
    public static string FormatDayAndMonth(this DateTime date)
    {
        return date.ToString("d MMMM");
    }
}