 using System;
 using System.Collections.Generic;

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
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
