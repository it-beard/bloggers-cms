using System;
using System.Collections.Generic;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Person
{
    public class PersonContentDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
    }
}