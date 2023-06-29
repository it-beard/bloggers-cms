using Pds.Core.Enums;

namespace Pds.Services.Models.Content;

public class EditContentModel
{
    public Guid Id { get; set; }

    public ContentType Type { get; set; }

    public SocialMediaType SocialMediaType { get; set; }

    public string Title { get; set; }

    public string Comment { get; set; }

    public DateTime ReleaseDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsContentFree { get; set; }

    public bool IsFilmed { get; set; }

    public EditContentBillModel Bill { get; set; }

    public Guid? PersonId { get; set; }
}