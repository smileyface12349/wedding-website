namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteImage(string url, string? altText) : IWebsiteElement
{
    private string Url { get; } = url;
    private string? AltText { get; } = altText;

    public string GetHtml(string classList = "") {
        return $"<img class=\"{classList}\" src=\"{Url}\" alt=\"{AltText ?? "Image"}\" />";
    }
}