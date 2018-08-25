 namespace AIBot.Core.Utility
{
    public static class Extentions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static string ApplyRegx(this string value, string replace)
        {
            return value.Replace("#name#", replace);
        }
    }
}
