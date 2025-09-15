using WeddingWebsite.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Contains data about a section of the website, used in configuration.
/// </summary>
public abstract record Section
{
    public abstract SectionType Type { get; }
    public SectionTheme Theme { get; }

    private Section(SectionTheme theme) {
        Theme = theme;
    }
    
    /// <summary>
    /// A countdown timer to the start of the first event.
    /// </summary>
    public sealed record Countdown(SectionTheme Theme) : Section(Theme)
    {
        public override SectionType Type => SectionType.Countdown;
    }
    
    /// <summary>
    /// A timeline of all the events happening in the day, including travel directions and accommodation.
    /// </summary>
    public sealed record Timeline(SectionTheme Theme) : Section(Theme)
    {
        public override SectionType Type => SectionType.Timeline;
    }
    
    /// <summary>
    /// Introductions from the wedding party
    /// </summary>
    public sealed record MeetWeddingParty(
        SectionTheme Theme,
        MeetWeddingPartyDisplay DisplayMode = MeetWeddingPartyDisplay.Default
    ) : Section(Theme)
    {
        public override SectionType Type => SectionType.MeetWeddingParty;
    }
    
    /// <summary>
    /// Shows suggested contacts based on what the enquiry is about.
    /// </summary>
    public sealed record Contact(SectionTheme Theme) : Section(Theme)
    {
        public override SectionType Type => SectionType.Contact;
    }
}