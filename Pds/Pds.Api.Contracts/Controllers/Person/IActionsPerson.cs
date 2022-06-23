using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Person;

public interface IActionsPerson
{
    Guid Id { get; set; }

    PersonStatus Status { get; set; }
    
    string FullName { get; set; }
    
    int ContentsCount { get; set; }
}