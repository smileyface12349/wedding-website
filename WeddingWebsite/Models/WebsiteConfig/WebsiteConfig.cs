using WeddingWebsite.Models.Theme;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour("#A3D5E0"),
        new Colour("#B6D7A8"),
        new Colour("#F2F1ED")
    );
    public IEnumerable<Section> Sections { get; }
    public TopButtonsConfig TopButtons { get; }
    
    public WebsiteConfig() {
        var surfaceVariant = new Colour(254, 252, 231);
        
        var purple = new Colour("#DCCCEC");

        var filledBox = new BoxStyle(BoxType.FilledRounded, new SectionTheme(Colours.PrimaryBackground, Colours.Primary, null));
        var outlinedBox = new BoxStyle(BoxType.OutlinedSquare, new SectionTheme(Colour.White, Colours.Primary, null));
    
        Sections = [
            new Section.Timeline(new SectionTheme(Colours.Surface, Colours.Primary, outlinedBox), true),
            new Section.DressCode(new SectionTheme(purple, Colours.Primary, filledBox)),
            new Section.MeetWeddingParty(new SectionTheme(Colours.Surface, Colours.Primary, outlinedBox)),
            new Section.Contact(new SectionTheme(Colours.Secondary, Colours.Primary, filledBox))
        ];

        var coral = new Colour(239, 111, 108);
        var salmon = new Colour(236, 129, 108, Colour.VeryDarkGrey);
        var lightGreen = new Colour(112, 229, 130);
        
        TopButtons = new TopButtonsConfig(
            [
                new LinkButton("Accommodation", "#accommodation")
            ],
            new Colour("#F9DC5C")
        );
    }
}