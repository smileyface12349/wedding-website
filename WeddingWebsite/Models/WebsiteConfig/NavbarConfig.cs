using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

public record NavbarConfig(
    IEnumerable<LinkButton> Items,
    Colour? Colour = null
);