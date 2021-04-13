namespace Pds.Web.Components.Pagination
{
    internal class PageModel
    {
        public string Text { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Active { get; set; } = false;

        public PageModel(int page) : this(page, true) { }

        public PageModel(int page, bool enabled) : this(page, enabled, page.ToString()) { }

        public PageModel(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
