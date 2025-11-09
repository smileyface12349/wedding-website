namespace WeddingWebsite.Models.WebsiteConfig;

public abstract record DemoMode(bool IsEnabled)
{
    public record Enabled(IEnumerable<string> LoginMessage) : DemoMode(true);

    public record Disabled() : DemoMode(false);
}