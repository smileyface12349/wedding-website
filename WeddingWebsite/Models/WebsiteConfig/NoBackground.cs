namespace WeddingWebsite.Models.WebsiteConfig;

public sealed record NoBackground : IBackground
{
    public bool ExtraContrast => false;
    public bool IsDark => false;
    public bool HasPureCssImplementation => true;

    public string GetBackgroundCss()
    {
        return "background: none;";
    }
    public Colour GetTextColour()
    {
        return Colour.DarkGrey;
    }
    
}