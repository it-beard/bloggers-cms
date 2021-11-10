using Pds.Core.Enums;

namespace Pds.Services.Models.Content;

public class EditContentBillModel
{
    public Guid ClientId { get; set; }

    public string Contact { get; set; }

    public string ContactName { get; set; }
        
    public ContactType ContactType { get; set; }

    public decimal Value { get; set; }
        
}