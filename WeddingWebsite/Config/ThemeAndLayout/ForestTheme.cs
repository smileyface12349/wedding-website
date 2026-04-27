using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.ThemeAndLayout;

public class ForestTheme : DefaultConfig, IWebsiteConfig
{
    public new WeddingColours Colours { get; } = new (
        new Colour("#606c38", true),
        new Colour("#606c38", true),
        new Colour("#bc6c25"),
        new Colour("#283618", true),
        new Colour("#fefae0")
    );

    public ForestTheme() {
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colour.White, Colours.Primary, null));
        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colour.White, Colours.Primary, null));
        
        var forest = new BackgroundImage("https://www.metroparks.net/wp-content/uploads/2017/06/1080p_HBK_autumn-morning_GI.jpg", false, "100%", null, 1);
        
        Sections = [
            new Section.TodoListSummary(new SectionTheme(Colours.Surface, Colour.White, outlinedBox)),
            new Section.HowWeMet(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox)),
            new Section.Timeline(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox)),
            new Section.DressCode(new SectionTheme(forest, Colours.Secondary, outlinedBox)),
            new Section.MeetWeddingParty(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox), MeetWeddingPartyDisplay.TwoRows),
            new Section.SimpleContact(new SectionTheme(Colours.Surface, Colours.Secondary, filledBox)),
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("Accommodation", "#accommodation"),
                new LinkButton("RSVP", "/rsvp")
            ],
            Colours.Primary
        );

        Navbar = new NavbarConfig(
            [
                new LinkButton("Home", "/"),
                new LinkButton("Order of the Day", "/#timeline"),
                new LinkButton("Gift List", "/registry"),
                new LinkButton("Contact", "/#contact")
            ],
            Colour: Colours.Secondary
        );

        AccountConfig = new PageConfig.Account(new SectionTheme(Colours.Surface, Colours.Secondary, filledBox));
        RegistryConfig = new PageConfig.Registry(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox));
        RegistryItemConfig = new PageConfig.RegistryItem(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox));
        LoginConfig = new PageConfig.Login(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox));
    }
}