using System;

namespace MvcMusicStore.Utilities
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            var lengthOfString = value.Length;
            if (lengthOfString <= maxLength)
                return value;

            var nextSpace = value.IndexOf(" ", maxLength - 1, StringComparison.Ordinal);
            if(nextSpace == -1)
            {
                if(lengthOfString > maxLength + 5)
                {
                    var indexOfLastSpace = value.LastIndexOf(" ", StringComparison.Ordinal);
                    var indexOfLastWord = value.IndexOf(
                        value.Substring(indexOfLastSpace, (lengthOfString - indexOfLastSpace - 2)),
                        StringComparison.Ordinal);
                    return value.Substring(0, indexOfLastWord) + "...";
                }
                return value + "...";
            }

            var subString = value.Substring(0, nextSpace);
            var lengthOfSubString = subString.Length;
            if (lengthOfSubString == lengthOfString)
                return subString;

            var newString = subString + "...";

            return newString;
        }
    }
}
