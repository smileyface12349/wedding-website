using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.ThemeAndLayout;

public class DefaultConfig : IWebsiteConfig
{
    public WeddingColours Colours { get; } = new (
        new Colour("#b9b8ff"),
        new Colour("#d0f0ff"),
        new Colour("#b9b8ff"),
        new Colour("#F8F8EF")
    );
    public IReadOnlyList<Section> Sections { get; protected set; }
    public TopButtonsConfig TopButtons { get; protected set; }
    public NavbarConfig Navbar { get; protected set; }
    public bool BrideFirst => false;
    public PageConfig.Account AccountConfig { get; set; }
    public PageConfig.Registry RegistryConfig { get; set; }
    public PageConfig.RegistryItem RegistryItemConfig { get; set; }
    public PageConfig.Login LoginConfig { get; set; }
    public PageConfig.Rsvp RsvpConfig { get; init; }
    public DemoMode DemoMode => new DemoMode.Disabled();
    public IEnumerable<string> IgnoredValidationIssues => [];

    // Default config will enable all optional features.
    public OptionalFeatures OptionalFeatures { get; } = new OptionalFeatures
    {
        Registry = new ActiveFeature()
    };

    public DefaultConfig() {
        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colours.SurfaceVariant, Colours.Primary, null));
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colours.SurfaceVariant, Colours.Primary, null));

        Sections = [
            new Section.HowWeMet(),
            new Section.Timeline(),
            new Section.DressCode(),
            new Section.Contact()
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("RSVP", "/rsvp")
            ],
            Colours.Secondary
        );

        Navbar = new NavbarConfig(
            [
                new LinkButton("Home", "/"),
                new LinkButton("Timeline & Transport", "/#timeline"),
                new LinkButton("Registry", "/registry"),
                new LinkButton("Gallery", "/gallery"),
                new LinkButton("Contact", "/#contact")
            ]
        );

        AccountConfig = new PageConfig.Account(new SectionTheme(Colours.PrimaryBackground.WithAlpha(150), Colours.Secondary, filledBox));
        RsvpConfig = new PageConfig.Rsvp(AccountConfig.Theme);
        RegistryConfig = new PageConfig.Registry(new SectionTheme(Colours.Surface, Colours.Primary, outlinedBox));
        RegistryItemConfig = new PageConfig.RegistryItem(new SectionTheme(Colours.Surface, Colours.Primary, filledBox));
        LoginConfig = new PageConfig.Login(new SectionTheme(Colours.PrimaryBackground, Colours.Primary, filledBox));
    }
}