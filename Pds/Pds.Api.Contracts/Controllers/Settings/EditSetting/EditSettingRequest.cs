using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Settings.EditSetting;

public class EditSettingRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Value { get; set; }
}