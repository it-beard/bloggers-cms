using Pds.Core.Enums;

namespace Pds.Web.Models.Content;

public class ContentStatusFilterItem
{
    public ContentStatus ContentStatus { get; set; }

    public bool IsSelected { get; set; }
}