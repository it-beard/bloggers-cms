using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Person
{
    public class UpdatePersonRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        
        /// <summary>
        /// General information about person
        /// </summary>
        public string Information { get; set; }
        
        /// <summary>
        /// Rate (int) - can be from 0 to 100 and used to understanding how attractable/hot user for the show
        /// </summary>
        public int Rate { get; set; }
    }
}