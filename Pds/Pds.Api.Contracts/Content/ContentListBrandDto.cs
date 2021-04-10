using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Attributes;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class ContentListBrandDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}