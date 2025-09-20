namespace WeddingWebsite.Models.WebsiteConfig;

public record BackgroundImage(string Url, bool IsDark, string Width = "100%", Colour? OverlayColour = null, float ParallaxPercent = 0) : IBackground
{
    public Colour GetTextColour() => IsDark ? Colour.White : Colour.Black;
    public string GetBackgroundCss() {
        var css = $"background-image: url('{Url}'); background-size: {Width} auto;";
        if (OverlayColour != null) {
            css += $"box-shadow: inset 0 0 0 2000px {OverlayColour};";
        }
        if (ParallaxPercent != 0) {
            if (ParallaxPercent >= 0.99) {
                css += "background-attachment: fixed;";
            } else {
                throw new NotImplementedException();
            }
        }
        return css;
    } 
    
}