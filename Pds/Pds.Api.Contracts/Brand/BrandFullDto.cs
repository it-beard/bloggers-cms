using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Content.GetContents;
using Pds.Api.Contracts.Cost;
using Pds.Api.Contracts.Gift;
using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Brand;

public class BrandFullDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public string Info { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public List<BillDto> Bills { get; set; }

    public List<CostDto> Costs { get; set; }

    public List<GetContentsContentDto> Contents { get; set; }

    public List<PersonDto> Persons { get; set; }

    public List<GiftDto> Gifts { get; set; }
}