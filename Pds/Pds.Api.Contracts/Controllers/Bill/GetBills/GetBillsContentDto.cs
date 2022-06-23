using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Bill.GetBills;

public class GetBillsContentDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public SocialMediaType SocialMediaType { get; set; }
}