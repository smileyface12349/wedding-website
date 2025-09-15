using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public class Colour
{
    public MudColor MudColor { get; }
    public bool IsDark { get; }
    
    public Colour(byte red, byte green, byte blue, bool isDark = false) {
        MudColor = new (red, green, blue, (byte) 255);
        IsDark = isDark;
    }
    
    public Colour(string hex)
    {
        MudColor = (MudColor) hex;
    }
    
    public Colour(MudColor mudColor) {
        MudColor = mudColor;
    }
    
    public static Colour White => new Colour(255, 255, 255, false);
}