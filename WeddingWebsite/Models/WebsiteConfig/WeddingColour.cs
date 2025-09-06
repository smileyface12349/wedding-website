using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WeddingColour
{
    public MudColor MudColor { get; }
    
    public WeddingColour(byte red, byte green, byte blue, byte alpha = 255) {
        MudColor = new (red, green, blue, alpha);
    }
    
    public WeddingColour(string hex)
    {
        MudColor = (MudColor) hex;
    }
    
    public WeddingColour(MudColor mudColor) {
        MudColor = mudColor;
    }
}