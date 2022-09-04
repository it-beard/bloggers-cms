using Pds.Core.Enums;

namespace Pds.Web.Models.Person;

public class PersonStatusFilterItem
{
    public PersonStatus PersonStatus { get; set; }

    public bool IsSelected { get; set; }
}