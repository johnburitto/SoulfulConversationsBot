namespace Schedule.Extensions
{
    public static class StringExtensions
    {
        public static string Repeat(this string str, int times)
        {
            return string.Concat(Enumerable.Repeat(str, times));
        }
    }
}
