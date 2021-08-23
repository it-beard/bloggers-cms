using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Topic
{
    public class CheckBoxPersonDto : PersonDto
    {
        public CheckBoxPersonDto(PersonDto personDto)
        {
            Id = personDto.Id;
            FullName = personDto.FullName;
            Location = personDto.Location;
            Info = personDto.Info;
            Rate = personDto.Rate;
            Status = personDto.Status;
            Resources = personDto.Resources;
            Contents = personDto.Contents;
        }

        public bool IsSelected { get; set; }
    }
}