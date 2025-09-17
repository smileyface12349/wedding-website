using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Configuration options. None of this information should be sensitive, and it should be stuff that relates to
/// configuring the website rather than anything related to a particular wedding.
///
/// Configuration options that relate to one section only can be found within that particular section's constructor.
/// </summary>

public interface IWebsiteConfig
{
    public WeddingColours Colours { get; }
    public IEnumerable<Section> Sections { get; }
    
}