using System.ComponentModel;

namespace WeddingWebsite.Core;

public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        
        if (field == null) 
        {
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }
        
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }
        
        throw new ArgumentException("Item not found.", nameof(enumValue));
    }
}