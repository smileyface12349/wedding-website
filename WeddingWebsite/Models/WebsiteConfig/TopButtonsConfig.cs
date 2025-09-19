using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

public record TopButtonsConfig(
    IEnumerable<LinkButton> Buttons,
    Colour? Colour = null
);