using System;

namespace Pds.Api.Contracts.Person
{
    public class ChannelDto 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}