using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Contains data about a section of the website, used in configuration.
/// </summary>
public abstract record Section
{
    public SectionTheme? Theme { get; }

    private Section(SectionTheme? theme) {
        Theme = theme;
    }
    
    /// <summary>
    /// A countdown timer to the start of the first event.
    /// Note: If this is not given, it will automatically display in the top section instead.
    /// </summary>
    public sealed record Countdown(SectionTheme? Theme = null) : Section(Theme);
    
    /// <summary>
    /// A timeline of all the events happening in the day, including travel directions and accommodation.
    /// Unlike most sections, the heading is disabled by default. This is because it looks nice with the timeline
    /// running right to the edge of the section, and the purpose of the section is clear already.
    /// </summary>
    public sealed record Timeline(SectionTheme? Theme = null, bool ShowHeading = false) : Section(Theme);
    
    /// <summary>
    /// Introductions from the wedding party
    /// </summary>
    public sealed record MeetWeddingParty(
        SectionTheme? Theme,
        IEnumerable<Role> RolesLeft,
        IEnumerable<Role> RolesRight,
        MeetWeddingPartyDisplay DisplayMode = MeetWeddingPartyDisplay.TwoColumns
    ) : Section(Theme)
    {
        public MeetWeddingParty(SectionTheme? theme = null, MeetWeddingPartyDisplay displayMode = MeetWeddingPartyDisplay.TwoColumns) 
            : this(theme, [Role.Groom, Role.BestMan, Role.Groomsman], [Role.Bride, Role.MaidOfHonour, Role.Bridesmaid], displayMode) {}
    }
    
    /// <summary>
    /// Shows suggested contacts based on what the enquiry is about.
    /// </summary>
    public sealed record Contact(
        SectionTheme? Theme,
        IEnumerable<ContactReason> ReasonsToShow,
        bool ShowUrgencyOption = true
    ) : Section(Theme)
    {
        public Contact(SectionTheme? theme = null, bool urgencyOption = true)
            : this(theme, Enum.GetValues<ContactReason>(), urgencyOption) {}
    }

    /// <summary>
    /// Shows the dress code. By default, it is shown inside a box.
    /// </summary>
    public sealed record DressCode(
        SectionTheme? Theme = null, 
        bool WrapInBox = true,
        bool ShowContact = true
    ) : Section(Theme);

    /// <summary>
    /// A showcase of the venues. All this information is already in the timeline.
    /// </summary>
    public sealed record VenueShowcase(SectionTheme? Theme = null) : Section(Theme);
    
    /// <summary>
    /// Shows accommodation details. All this information is already in the timeline.
    /// </summary>
    public sealed record Accommodation(SectionTheme? Theme = null) : Section(Theme);

    /// <summary>
    /// A simple section with images either side and some text in the middle. If you want to add more detail, please
    /// add a new section called "Our Story" using a timeline component instead of modifying this section.
    /// </summary>
    public sealed record HowWeMet(SectionTheme? Theme = null) : Section(Theme);

    /// <summary>
    /// Displays to admins only (unless a non-admin has been assigned a task). Shows all tasks marked as
    /// "Action Required", either assigned to the particular user or ones that are assigned to nobody.
    /// </summary>
    public sealed record TodoListSummary(SectionTheme? Theme = null) : Section(Theme);
}