using Pds.Core.Enums;

namespace Pds.Web.Models.Client;

public class ClientStatusFilterItem
{
    public ClientStatus ClientStatus { get; set; }

    public bool IsSelected { get; set; }
}