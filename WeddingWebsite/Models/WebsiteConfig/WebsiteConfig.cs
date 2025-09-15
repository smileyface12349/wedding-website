using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.No;
    public WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour(255, 182, 193),
        new Colour(254, 252, 231),
        new Colour(39, 92, 52),
        new Colour(255, 255, 255)
    );
    public IEnumerable<Role> IntroductionRolesGroom => [Role.Groom, Role.BestMan, Role.Groomsman];
    public IEnumerable<Role> IntroductionRolesBride => [Role.Bride, Role.MaidOfHonour, Role.Bridesmaid];
    public MeetWeddingPartyDisplay MeetWeddingPartyDisplay => MeetWeddingPartyDisplay.Default;
    public IEnumerable<ContactReason> ContactReasonsToShow => Enum.GetValues<ContactReason>();
    public bool ShowContactUrgencyOption => true;
    public IEnumerable<Section> Sections { get; }
    
    public WebsiteConfig() {
        var theme1 = new SectionTheme(
            Colour.White,
            Colours.Primary,
            new BoxStyle(BoxType.Outlined, Colours.SurfaceVariant)
        );
        
        var theme2 = new SectionTheme(
            Colours.SurfaceVariant,
            Colours.Primary,
            new BoxStyle(BoxType.Outlined, Colour.White)
        );
        
        var theme3 = new SectionTheme(
            Colours.Tertiary,
            Colours.Primary,
            new BoxStyle(BoxType.Outlined, Colour.White)
        );
    
        Sections = [
            new Section.Countdown(theme2),
            new Section.Timeline(theme2),
            new Section.MeetWeddingParty(theme1),
            new Section.Contact(theme3)
        ];
    }
}