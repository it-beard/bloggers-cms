using System.Collections.Generic;

namespace Pds.Api.Contracts.Person
{
    public class PersonDto
    {
        public string Id { get; set; }
        
        public string FullName { get; set; }
        
        public string Location { get; set; }
        
        public string Information { get; set; }
        
        public int Rate { get; set; }
        
        public List<ResourceDto> Resources { get; set; }
    }
}