using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.ThemeAndLayout;

public class SummerTheme : DefaultConfig, IWebsiteConfig
{
    public new WeddingColours Colours { get; } = new (
        new Colour("#ffbaba"),
        new Colour("#ffd6d6"),
        new Colour("#8D8BFA"),
        new Colour("#fff4e8")
    );

    public SummerTheme() {
        var orange = new Colour("#ffe3c6");
        var yellow = new Colour("#fff2b5");
        var green = new Colour("#ccecd1");
        var lightBlue = new Colour("#d0f0ff");
        var salmon = new Colour(236, 129, 108, Colour.VeryDarkGrey);
        
        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(lightBlue, Colours.Secondary, null));
        var whiteFilledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colour.White, Colours.Primary, null));
        
        var flowers = new BackgroundImage("/bg/blue-flowers.png", false, "500px", new Colour(255, 255, 255, 150), 0.3, true);
        var beach = new BackgroundImage("https://upload.wikimedia.org/wikipedia/commons/1/1f/Beach_sunset_%28Unsplash%29.jpg", true, OverlayColour: new Colour(0, 0, 0, 50), Parallax: 1);
    
        Sections = [
            new Section.TodoListSummary(new SectionTheme(salmon, Colour.White, filledBox)),
            new Section.VenueShowcase(new SectionTheme(orange, Colours.Primary, filledBox)),
            new Section.SimpleTimeline(new SectionTheme(beach, Colours.Primary, filledBox)),
            new Section.Accommodation(new SectionTheme(green, Colours.Primary, filledBox)),
            new Section.Gallery(),
            new Section.MeetWeddingParty(new SectionTheme(flowers, Colours.Primary, filledBox), MeetWeddingPartyDisplay.Chat),
            new Section.SimpleContact(new SectionTheme(green, Colours.Primary, filledBox)),
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("Accommodation", "#accommodation"),
                new LinkButton("RSVP", "/rsvp")
            ],
            yellow
        );

        Navbar = new NavbarConfig(
            [
                new LinkButton("Home", "/"),
                new LinkButton("Timeline & Transport", "/#timeline"),
                new LinkButton("Accommodation", "/#accommodation"),
                new LinkButton("Registry", "/registry"),
                new LinkButton("Gallery", "/gallery"),
                new LinkButton("Contact", "/#contact")
            ]
        );

        AccountConfig = new PageConfig.Account(new SectionTheme(Colours.Surface, Colours.Primary, filledBox));
        RegistryConfig = new PageConfig.Registry(new SectionTheme(Colours.Surface, Colours.Primary, whiteFilledBox));
        RegistryItemConfig = new PageConfig.RegistryItem(new SectionTheme(Colours.Surface, Colours.Primary, whiteFilledBox));
        LoginConfig = new PageConfig.Login(new SectionTheme(Colours.Surface, Colours.Primary, filledBox));
    }
}