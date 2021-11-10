namespace Pds.Core.Extensions;

public static class GuidExtensions
{
    public static string ToShortString(this Guid guid)
    {
        return guid.ToString().Substring(0, 7);
    }
}