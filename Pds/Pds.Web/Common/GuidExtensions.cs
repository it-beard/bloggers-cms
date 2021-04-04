using System;

namespace Pds.Web.Common
{
    public static class GuidExtensions
    {
        public static string ToShortString(this Guid guid)
        {
            return guid.ToString().Substring(0, 7);
        }
    }
}