namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteImage(string url, string? altText) : IWebsiteElement
{
    public string Url { get; } = url;
    public string? AltText { get; } = altText;

    public string GetHtml(string classList = "") {
        return $"<img class=\"{classList}\" src=\"{Url}\" alt=\"{AltText ?? "Image"}\" />";
    }
}