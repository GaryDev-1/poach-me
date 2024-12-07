namespace WildlifePoaching.API.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetCurrentUtcDateTime()
        {
            return DateTime.UtcNow;
        }

        public static bool IsWithinTimeframe(DateTime date, TimeSpan timeframe)
        {
            return (DateTime.UtcNow - date) <= timeframe;
        }

        public static DateTime GetStartOfDay(DateTime date)
        {
            return date.Date;
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }
    }
}
