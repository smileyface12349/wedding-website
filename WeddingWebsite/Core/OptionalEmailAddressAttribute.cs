using System.ComponentModel.DataAnnotations;

namespace WeddingWebsite.Core;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public sealed class OptionalEmailAddressAttribute : DataTypeAttribute
{
    public OptionalEmailAddressAttribute()
        : base(DataType.EmailAddress)
    {
        ErrorMessage = "The {0} field is not a valid e-mail address.";
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        if (!(value is string valueAsString))
        {
            return false;
        }

        if (valueAsString == "")
        {
            return true;
        }

        if (valueAsString.AsSpan().ContainsAny('\r', '\n'))
        {
            return false;
        }

        // only return true if there is only 1 '@' character
        // and it is neither the first nor the last character
        int index = valueAsString.IndexOf('@');

        return
            index > 0 &&
            index != valueAsString.Length - 1 &&
            index == valueAsString.LastIndexOf('@');
    }
}