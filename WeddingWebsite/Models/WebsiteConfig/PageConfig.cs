using WeddingWebsite.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

public abstract record PageConfig(SectionTheme? Theme = null)
{
    public sealed record Account(SectionTheme? Theme = null) : PageConfig(Theme);
    public sealed record Registry(SectionTheme? Theme = null) : PageConfig(Theme);
    public sealed record RegistryItem(SectionTheme? Theme = null) : PageConfig(Theme);
    public sealed record Login(SectionTheme? Theme = null, string UserNamePlaceholder = "name@example.com") : PageConfig(Theme);
}