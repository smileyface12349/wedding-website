namespace WeddingWebsite.Models.WebsiteConfig;

public record DemoMode(
    bool IsEnabled = true,
    string Message = ""
)
{
    public static readonly DemoMode Disabled = new DemoMode(false);
}