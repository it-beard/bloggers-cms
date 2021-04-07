using System;

namespace Pds.Api.Contracts.Content
{
    public class GetContentBillClientDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Comment { get; set; }
    }
}