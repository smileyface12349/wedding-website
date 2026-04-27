using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.ThemeAndLayout;

public class UnderwaterTheme : DefaultConfig, IWebsiteConfig
{
    public new WeddingColours Colours { get; } = new (
        new Colour("#62b6cb"),
        new Colour("#cae9ff"),
        new Colour("#9ec1a3"),
        new Colour("#cae9ff")
    );

    public UnderwaterTheme() {
        var yellow = new Colour("#fff2b5");
        
        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colour.White, Colours.Secondary, null));
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colour.White, Colours.Primary, null));
        
        var planks = new BackgroundImage("https://images.pexels.com/photos/172292/pexels-photo-172292.jpeg", true, Parallax: 0.3);
        
        Sections = [
            new Section.TodoListSummary(new SectionTheme(Colours.Surface, Colour.White, filledBox)),
            new Section.Timeline(new SectionTheme(Colours.Surface, Colours.Secondary, filledBox)),
            new Section.DressCode(new SectionTheme(planks, Colours.Primary, filledBox)),
            new Section.Contact(new SectionTheme(Colours.Surface, Colours.Secondary, filledBox)),
        ];
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("RSVP", "/rsvp")
            ],
            yellow
        );

        Navbar = new NavbarConfig(
            [
                new LinkButton("Home", "/"),
                new LinkButton("Logistics", "/#timeline"),
                new LinkButton("Registry", "/registry"),
                new LinkButton("Gallery", "/gallery")
            ],
            new Colour("#6db2e3")
        );

        AccountConfig = new PageConfig.Account(new SectionTheme(Colours.Surface, Colours.Primary, filledBox));
        RegistryConfig = new PageConfig.Registry(new SectionTheme(Colours.Surface, Colours.Secondary, outlinedBox));
        RegistryItemConfig = new PageConfig.RegistryItem(new SectionTheme(Colours.Surface, Colours.Secondary, filledBox));
        LoginConfig = new PageConfig.Login(new SectionTheme(Colours.Surface, Colours.Primary, filledBox));
    }
}