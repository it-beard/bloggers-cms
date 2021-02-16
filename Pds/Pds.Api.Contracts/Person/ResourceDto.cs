using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pds.Data.Entities;

namespace Pds.Api.Contracts.Person
{
    public class ResourceDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}