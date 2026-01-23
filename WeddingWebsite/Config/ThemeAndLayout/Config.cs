using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.ThemeAndLayout;

public class Config : DefaultConfig, IWebsiteConfig
{
    public new WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour("#A3D5E0"),
        new Colour("#B6D7A8"),
        new Colour("#F2F1ED")
    );
    public new IReadOnlyList<Section> Sections { get; protected set; }
    public new TopButtonsConfig TopButtons { get; }
    public new NavbarConfig Navbar { get; }
    public new bool BrideFirst => false;
    public new PageConfig.Account AccountConfig { get; set; }
    public new PageConfig.Registry RegistryConfig { get; set; }
    public new PageConfig.RegistryItem RegistryItemConfig { get; set; }
    public new PageConfig.Login LoginConfig { get; set; }
    
    // Default config will enable all optional features.
    public new OptionalFeatures OptionalFeatures { get; } = new OptionalFeatures
    {
        Registry = new ActiveFeature()
    };

    public Config() {
        var surfaceVariant = new Colour(254, 252, 231);
        
        var purple = new Colour("#DCCCEC");
        var coral = new Colour(239, 111, 108);
        var salmon = new Colour(236, 129, 108, Colour.VeryDarkGrey);
        var lightGreen = new Colour(112, 229, 130);
        var darkGreen = new Colour(50, 150, 50);
        var yellow = new Colour("#F9DC5C");
        var darkPurple = new Colour(137, 108, 166);

        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colours.PrimaryBackground, darkPurple, null));
        var whiteFilledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colour.White, Colours.Primary, null));
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colour.White, Colours.Primary, null));
        
        var bricks = new BackgroundImage("/bg/bricks.jpg", false, "500px", new Colour(255, 255, 255, 150), 0.3, true);
        var flowers = new BackgroundImage("/bg/blue-flowers.png", false, "500px", new Colour(255, 255, 255, 150), 0.3, true);
    
        Sections = [
            new Section.TodoListSummary(new SectionTheme(salmon, Colour.White, new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colours.PrimaryBackground, Colour.White, null)))),
            //new Section.HowWeMet(new SectionTheme(purple, Colours.Primary, filledBox)),
            new Section.DressCode(new SectionTheme(purple, Colours.Primary, filledBox), true, false),
            new Section.Timeline(new SectionTheme(bricks, Colours.Primary, outlinedBox), true),
            new Section.VenueShowcase(new SectionTheme(purple, Colours.Primary, filledBox)),
            //new Section.MeetWeddingParty(new SectionTheme(flowers, Colours.Primary, outlinedBox)),
            new Section.Accommodation(new SectionTheme(purple, Colours.Primary, filledBox)),
            //new Section.Gallery(),
            //new Section.Contact(new SectionTheme(Colours.Secondary, Colours.Primary, whiteFilledBox))
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("Transport", "#accommodation")
            ],
            yellow
        );

        Navbar = new NavbarConfig(
            [
                new LinkButton("Home", "/"),
                new LinkButton("Schedule", "/#timeline"),
                new LinkButton("Directions", "/#accommodation"),
                new LinkButton("Registry", "/registry"),
                //new LinkButton("Gallery", "/gallery"),
                //new LinkButton("Contact", "/#contact")
            ]
        );

        AccountConfig = new PageConfig.Account(new SectionTheme(Colours.PrimaryBackground.WithAlpha(150), purple, whiteFilledBox));
        
        RegistryConfig = new PageConfig.Registry(new SectionTheme(Colours.Surface, Colours.Primary, outlinedBox));
        RegistryItemConfig = new PageConfig.RegistryItem(new SectionTheme(Colours.Surface, Colours.Primary, whiteFilledBox));
        LoginConfig = new PageConfig.Login(new SectionTheme(Colours.PrimaryBackground, Colours.Primary, whiteFilledBox));
    }
}