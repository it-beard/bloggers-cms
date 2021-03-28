using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class CreateContentResponse
    {
        public Guid Id { get; set; }
    }
}