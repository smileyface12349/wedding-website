using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.No;
    public WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour(255, 182, 193),
        new Colour(254, 249, 231),
        new Colour(39, 92, 52),
        new Colour(255, 255, 255)
    );
    public IEnumerable<Role> IntroductionRolesGroom => [Role.Groom, Role.BestMan, Role.Groomsman];
    public IEnumerable<Role> IntroductionRolesBride => [Role.Bride, Role.MaidOfHonour, Role.Bridesmaid];
    public MeetWeddingPartyDisplay MeetWeddingPartyDisplay => MeetWeddingPartyDisplay.Default;
    public IEnumerable<ContactReason> ContactReasonsToShow => Enum.GetValues<ContactReason>();
    public bool ShowContactUrgencyOption => true;
}