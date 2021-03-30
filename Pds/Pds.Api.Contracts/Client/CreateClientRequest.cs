using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Client
{
    public class CreateClientRequest
    {
        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }
    }
}