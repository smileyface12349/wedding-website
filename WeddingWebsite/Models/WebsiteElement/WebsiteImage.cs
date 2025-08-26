namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteImage(string url, string? altText) : IWebsiteElement
{
    private string Url { get; } = url;
    private string? AltText { get; } = altText;

    public string GetHtml() {
        return $"<img src=\"{Url}\" alt=\"{AltText ?? "Image"}\" />";
    }
}