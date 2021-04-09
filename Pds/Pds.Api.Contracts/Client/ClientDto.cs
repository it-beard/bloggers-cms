using System;
using System.Collections.Generic;

namespace Pds.Api.Contracts.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Comment { get; set; }
        
        public List<ClientBillDto> Bills { get; set; }
    }
}