namespace WeddingWebsite.Models.WebsiteConfig;

public record BackgroundImage(string Url, bool IsDark, string Width = "100%", Colour? OverlayColour = null) : IBackground
{
    public Colour GetTextColour() => IsDark ? Colour.White : Colour.Black;
    public string GetBackgroundCss() {
        var overlay = OverlayColour != null ? $"box-shadow: inset 0 0 0 2000px {OverlayColour};" : "";
        return $"background-image: url('{Url}'); background-size: {Width} auto;{overlay}";
    } 
    
}