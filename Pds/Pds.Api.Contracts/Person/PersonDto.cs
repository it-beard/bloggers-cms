using System;
using System.Collections.Generic;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Person
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }
        
        public string Location { get; set; }
        
        public string Info { get; set; }
        
        public int Rate { get; set; }

        public PersonStatus Status { get; set; }
        
        public List<ResourceDto> Resources { get; set; }
        
        public List<PersonContentDto> Contents { get; set; }
    }
}