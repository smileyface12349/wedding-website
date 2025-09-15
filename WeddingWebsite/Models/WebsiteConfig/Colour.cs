using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public class Colour
{
    public MudColor MudColor { get; }
    
    public Colour(byte red, byte green, byte blue, byte alpha = 255) {
        MudColor = new (red, green, blue, alpha);
    }
    
    public Colour(string hex)
    {
        MudColor = (MudColor) hex;
    }
    
    public Colour(MudColor mudColor) {
        MudColor = mudColor;
    }
}