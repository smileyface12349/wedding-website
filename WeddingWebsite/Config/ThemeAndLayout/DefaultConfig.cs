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
            new Section.Custom("Welcome!", [
                new WebsiteSection("Welcome to your Wedding Website", ["As you can see, it's a bit basic to start with. This is done deliberately so that you can start from a blank slate and make something truly unique. There's plenty of pre-built sections that you can choose from, and you can customise all of the colours too.", "See 'Section.cs' for the full list of pre-built sections. You can also create your own ones, or ask me nicely on GitHub!"]),
                new WebsiteSection("Customisation Guide", ["First, head into the Config directory. This (and Program.cs) is the only place you will need to go to customise the website. You should see several folders like ThemeAndLayout and WeddingDetails. To start, go into ThemeAndLayout and open DefaultConfig.cs - you should find the text you are reading right now within the code! Take a moment to have a little look around this file.", "While you could edit this file directly, it is much better to create a new file within the same directory and inherit from DefaultConfig (see DemoConfig for an example). This means that new updates won't interfere with your changes. Try doing this and overriding the Sections attribute with the ones you actually want. Take a look at DemoConfig if you get stuck.", "Finally, head into Program.cs and change 'DefaultConfig' to the name of your new config file. You can make multiple config files and easily switch between them to test out what you (and your partner) like more. If you restart, this text will be gone.", "You'll need to repeat this for other aspects of config you want to change, like changing the wording on the website. I'd suggest taking a look at WeddingDetails next - this is where everything relating to your wedding goes, like the order of the day and names of people."]),
                new WebsiteSection(new LinkButton("View README", "https://github.com/smileyface12349/wedding-website/blob/main/README.md"))
            ]),
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