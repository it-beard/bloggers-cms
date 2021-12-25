using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities;

public class Setting : EntityBase
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Key { get; set; }

    [Required]
    public string Value { get; set; }
}