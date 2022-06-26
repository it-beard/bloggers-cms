namespace Pds.Web.Common;

public class PageHistoryState
{
    private List<string> pages;

    public PageHistoryState()
    {
       pages = new List<string>();
    }
    public void AddPage(string pageName)
    {
        pages.Add(pageName);
    }

    public string PreviousPage()
    {
        return pages.Last();
    }

    public bool CanGoBack()
    {
        return pages.Count > 0;
    }
    
    public void RemoveCurrent(string currentPage)
    {
        if (pages.Count == 0)
        {
            return;
        }
        
        var lastPage = pages.Last();
        if (lastPage == currentPage)
        {
            pages.Remove(pages.Last());
            RemoveCurrent(currentPage);
        }
    }
}
