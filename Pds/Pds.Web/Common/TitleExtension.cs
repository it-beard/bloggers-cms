namespace Pds.Web.Common
{
    public class TitleExtension
    {
        public static string WithSuffix(string title, bool nosuffix = false)
        {
            return nosuffix ? title : title + " / Bloggers CMS";
        }
    }
}