using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.No;
    public WeddingColours Colours { get; } = new (
        new WeddingColour(77, 204, 225),
        new WeddingColour(255, 182, 193),
        new WeddingColour(254, 249, 231)
    );
    public IEnumerable<Role> IntroductionRolesGroom => [Role.Groom, Role.BestMan, Role.Groomsman];
    public IEnumerable<Role> IntroductionRolesBride => [Role.Bride, Role.MaidOfHonour, Role.Bridesmaid];
    public MeetWeddingPartyDisplay MeetWeddingPartyDisplay => MeetWeddingPartyDisplay.Default;
    public IEnumerable<ContactReason> ContactReasonsToShow => Enum.GetValues<ContactReason>();
}