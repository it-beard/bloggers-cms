using Pds.Core.Enums;

namespace Pds.Web.Models.Content;

public class ContentTypeFilterItem
{
    public ContentType ContentType { get; set; }

    public bool IsSelected { get; set; }
}