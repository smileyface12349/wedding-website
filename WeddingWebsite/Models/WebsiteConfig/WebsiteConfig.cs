using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

public class WebsiteConfig : IWebsiteConfig
{
    public WeddingColours Colours { get; } = new (
        new Colour(77, 204, 225),
        new Colour(162, 234, 246),
        new Colour(39, 92, 52, true)
    );
    public IEnumerable<Section> Sections { get; }
    
    public WebsiteConfig() {
        var surfaceVariant = new Colour(254, 252, 231);
    
        var theme1 = new SectionTheme(
            Colour.White,
            Colours.Primary,
            new BoxStyle(BoxType.Outlined, new SectionTheme(Colour.White, Colours.Primary, null))
        );
        
        var theme2 = new SectionTheme(
            surfaceVariant,
            Colours.Primary,
            new BoxStyle(BoxType.Outlined, new SectionTheme(Colour.White, Colours.Primary, null))
        );
        
        var theme3 = new SectionTheme(
            Colours.Secondary,
            Colours.Primary,
            new BoxStyle(BoxType.Filled, new SectionTheme(Colours.PrimaryBackground, Colours.Primary, null))
        );
    
        Sections = [
            new Section.Countdown(theme1 with { BoxStyle = new BoxStyle(BoxType.Filled, new SectionTheme(Colours.PrimaryBackground, Colours.Primary, null))}),
            new Section.Timeline(theme2),
            new Section.MeetWeddingParty(theme1),
            new Section.Contact(theme3)
        ];
    }
}