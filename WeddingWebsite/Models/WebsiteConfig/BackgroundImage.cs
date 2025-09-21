namespace WeddingWebsite.Models.WebsiteConfig;

public record BackgroundImage(string Url, bool IsDark, string Width = "100%", Colour? OverlayColour = null, double Parallax = 0, bool ExtraContrast = false) : IBackground
{
    public bool HasPureCssImplementation => Parallax < 0.001 || Parallax > 0.999;
    public Colour GetTextColour() => IsDark ? Colour.White : Colour.Black;
    public string GetBackgroundCss() {
        var css = $"background-image: url('{Url}'); background-size: {Width} auto;";
        if (OverlayColour != null) {
            css += $"box-shadow: inset 0 0 0 2000px {OverlayColour};";
        }
        if (Parallax > 0.999) {
            css += "background-attachment: fixed;";
        } 
        return css;
    } 
    
}