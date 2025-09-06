namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Configuration options. None of this information should be sensitive, and it should be stuff that's personal
/// preference rather than details about a particular wedding.
/// </summary>

public interface IWebsiteConfig
{
    public UsersCanAddGuests UsersCanAddGuests { get; }
    public WeddingColours Colours { get; }
    
}