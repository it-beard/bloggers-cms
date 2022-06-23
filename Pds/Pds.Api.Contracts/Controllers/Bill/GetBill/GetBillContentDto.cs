using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Bill.GetBill;

public class GetBillContentDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public SocialMediaType SocialMediaType { get; set; }
}