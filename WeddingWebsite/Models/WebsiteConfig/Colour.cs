using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public class Colour
{
    private readonly MudColor mudColor;
    private readonly Colour? customTextColour;
    public bool IsDark { get; }
    
    public Colour(byte red, byte green, byte blue, bool isDark = false) {
        mudColor = new (red, green, blue, (byte) 255);
        IsDark = isDark;
    }

    /// <summary>
    /// Specify an entirely custom text colour. Warning: This is not always used.
    /// </summary>
    public Colour(byte red, byte green, byte blue, Colour textColour)
    {
        mudColor = new(red, green, blue, (byte)255);
        customTextColour = textColour;
        IsDark = !textColour.IsDark;
    }
    
    public Colour(string hex)
    {
        mudColor = (MudColor) hex;
    }
    
    public override string ToString() {
        return mudColor.ToString();
    }
    
    public string GetHex() {
        return mudColor.Value;
    }
    
    /// <summary>
    /// Obtain a suitable text colour to use against this background. Other text colours are fine too.
    /// </summary>
    public Colour GetTextColour() {
        if (customTextColour != null)
        {
            return customTextColour;
        }
        if (IsDark) {
            return White;
        } else {
            return DarkGrey;
        }
    }
    
    public static Colour White => new Colour(255, 255, 255, false);
    public static Colour DarkGrey => new Colour(66, 66, 66, true);
}