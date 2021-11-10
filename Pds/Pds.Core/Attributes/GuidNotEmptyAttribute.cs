using System.ComponentModel.DataAnnotations;

namespace Pds.Core.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class GuidNotEmptyAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var result = !((Guid) value == Guid.Empty);
        return result;
    }
}