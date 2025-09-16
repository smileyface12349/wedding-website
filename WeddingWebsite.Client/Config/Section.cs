using WeddingWebsite.Client.Models.Contacts;
using WeddingWebsite.Client.Models.Theme;
using WeddingWebsite.Client.Models.People;

namespace WeddingWebsite.Client.Config;

/// <summary>
/// Contains data about a section of the website, used in configuration.
/// </summary>
public abstract record Section
{
    public SectionTheme Theme { get; }

    private Section(SectionTheme theme) {
        Theme = theme;
    }
    
    /// <summary>
    /// A countdown timer to the start of the first event.
    /// Note: If this is not given, it will automatically display in the top section instead.
    /// </summary>
    public sealed record Countdown(SectionTheme Theme) : Section(Theme);
    
    /// <summary>
    /// A timeline of all the events happening in the day, including travel directions and accommodation.
    /// Unlike most sections, the heading is disabled by default. This is because it looks nice with the timeline
    /// running right to the edge of the section, and the purpose of the section is clear already.
    /// </summary>
    public sealed record Timeline(SectionTheme Theme, bool ShowHeading = false) : Section(Theme);
    
    /// <summary>
    /// Introductions from the wedding party
    /// </summary>
    public sealed record MeetWeddingParty(
        SectionTheme Theme,
        IEnumerable<Role> RolesLeft,
        IEnumerable<Role> RolesRight,
        MeetWeddingPartyDisplay DisplayMode = MeetWeddingPartyDisplay.Default
    ) : Section(Theme)
    {
        public MeetWeddingParty(SectionTheme theme, MeetWeddingPartyDisplay displayMode = MeetWeddingPartyDisplay.Default) 
            : this(theme, [Role.Groom, Role.BestMan, Role.Groomsman], [Role.Bride, Role.MaidOfHonour, Role.Bridesmaid], displayMode) {}
    }
    
    /// <summary>
    /// Shows suggested contacts based on what the enquiry is about.
    /// </summary>
    public sealed record Contact(
        SectionTheme Theme,
        IEnumerable<ContactReason> ReasonsToShow,
        bool ShowUrgencyOption = true
    ) : Section(Theme)
    {
        public Contact(SectionTheme theme, bool urgencyOption = true)
            : this(theme, Enum.GetValues<ContactReason>(), urgencyOption) {}
    }
}