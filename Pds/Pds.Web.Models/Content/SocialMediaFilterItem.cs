using Pds.Core.Enums;

namespace Pds.Web.Models.Content;

public class SocialMediaFilterItem
{
    public SocialMediaType SocialMediaType { get; set; }

    public bool IsSelected { get; set; }
}