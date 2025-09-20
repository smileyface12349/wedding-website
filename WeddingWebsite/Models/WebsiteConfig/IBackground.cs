namespace WeddingWebsite.Models.WebsiteConfig;

public interface IBackground
{
    public bool IsDark { get; }
    public Colour GetTextColour();
    public string GetBackgroundCss();
}