namespace Pds.Web.Common
{
    public static class TitleExtension
    {
        public static string WithSuffix(string title, bool nosuffix = false)
        {
            return nosuffix ? title : title + $" / {Constants.AppName}";
        }
    }
}