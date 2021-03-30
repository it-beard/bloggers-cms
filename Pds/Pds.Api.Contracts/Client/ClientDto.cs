using System;

namespace Pds.Api.Contracts.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Comment { get; set; }
    }
}