using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Configuration options. None of this information should be sensitive, and it should be stuff that relates to
/// configuring the website rather than anything related to a particular wedding.
///
/// Configuration options that relate to one section only can be found within that particular section's constructor.
/// </summary>

public interface IWebsiteConfig
{
    /// <summary>
    /// Colour theme. This is sometimes used, but usually overridden by the section themes.
    /// </summary>
    public WeddingColours Colours { get; }
    
    /// <summary>
    /// The sections to show on the website, and per-section config.
    /// </summary>
    public IEnumerable<Section> Sections { get; }
    
    /// <summary>
    /// The buttons to display on the top of the homepage e.g. "RSPV".
    /// </summary>
    public TopButtonsConfig TopButtons { get; }
}