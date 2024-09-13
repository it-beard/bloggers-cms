using Pds.Web.Models.Cost;

namespace Pds.Web.Models.Client;

public class FilterSettings
{
    public List<ClientStatusFilterItem> ClientStatusFilterItems { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}
