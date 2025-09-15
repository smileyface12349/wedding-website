using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Configuration options. None of this information should be sensitive, and it should be stuff that's personal
/// preference rather than details about a particular wedding.
/// </summary>

public interface IWebsiteConfig
{
    public WeddingColours Colours { get; }
    public IEnumerable<Role> IntroductionRolesGroom { get; }
    public IEnumerable<Role> IntroductionRolesBride { get; }
    public IEnumerable<ContactReason> ContactReasonsToShow { get; }
    public bool ShowContactUrgencyOption { get; }
    public IEnumerable<Section> Sections { get; }
    
}