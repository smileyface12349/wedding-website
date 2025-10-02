using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

public class DefaultConfig : IWebsiteConfig
{
    public WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour("#A3D5E0"),
        new Colour("#B6D7A8"),
        new Colour("#F2F1ED")
    );
    public IEnumerable<Section> Sections { get; }
    public TopButtonsConfig TopButtons { get; }
    public bool BrideFirst => false;
    public AccountConfig AccountConfig { get; set; }

    public DefaultConfig() {
        var surfaceVariant = new Colour(254, 252, 231);
        
        var purple = new Colour("#DCCCEC");
        var coral = new Colour(239, 111, 108);
        var salmon = new Colour(236, 129, 108, Colour.VeryDarkGrey);
        var lightGreen = new Colour(112, 229, 130);
        var darkGreen = new Colour(50, 150, 50);
        var darkYellow = new Colour(246, 190, 0);
        var darkPurple = new Colour(137, 108, 166);

        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colours.PrimaryBackground, darkPurple, null));
        var whiteFilledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colour.White, Colours.Primary, null));
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colour.White, Colours.Primary, null));
        
        var bricks = new BackgroundImage("/bg/bricks.jpg", false, "500px", new Colour(255, 255, 255, 150), 0.3, true);
        var flowers = new BackgroundImage("/bg/blue-flowers.png", false, "500px", new Colour(255, 255, 255, 150), 0.3, true);
    
        Sections = [
            new Section.HowWeMet(new SectionTheme(purple, Colours.Primary, filledBox)),
            new Section.Timeline(new SectionTheme(bricks, Colours.Primary, outlinedBox), true),
            new Section.VenueShowcase(new SectionTheme(purple, Colours.Primary, filledBox)),
            new Section.MeetWeddingParty(new SectionTheme(flowers, Colours.Primary, outlinedBox)),
            new Section.DressCode(new SectionTheme(purple, Colours.Primary, filledBox)),
            new Section.Contact(new SectionTheme(Colours.Secondary, Colours.Primary, whiteFilledBox))
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("Accommodation", "#accommodation")
            ],
            new Colour("#F9DC5C")
        );

        AccountConfig = new AccountConfig(new SectionTheme(Colours.PrimaryBackground.WithAlpha(150), purple, whiteFilledBox));
    }
}