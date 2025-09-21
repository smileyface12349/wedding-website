namespace WeddingWebsite.Models.WebsiteConfig;

public record BackgroundImage(string Url, bool IsDark, string Width = "100%", Colour? OverlayColour = null, bool Parallax = false, bool ExtraContrast = false) : IBackground
{
    public bool HasPureCssImplementation => true;
    public Colour GetTextColour() => IsDark ? Colour.White : Colour.Black;
    public string GetBackgroundCss() {
        var css = $"background-image: url('{Url}'); background-size: {Width} auto;";
        if (OverlayColour != null) {
            css += $"box-shadow: inset 0 0 0 2000px {OverlayColour};";
        }
        if (Parallax) {
            css += "background-attachment: fixed;";
        } 
        return css;
    } 
    
}