namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.No;
    public WeddingColours Colours { get; } = new (
        new WeddingColour(77, 204, 225),
        new WeddingColour(255, 182, 193),
        new WeddingColour(254, 249, 231)
    );
}