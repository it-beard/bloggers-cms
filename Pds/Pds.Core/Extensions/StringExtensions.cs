using System;

namespace Pds.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToCompare(this string value)
        {
            return value.ToLower().Trim();
        }
    }
}