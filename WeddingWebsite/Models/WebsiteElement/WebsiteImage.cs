namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteImage(string url, string? altText, IEnumerable<ImageSizeVariation> customSizes) : IWebsiteElement
{
    public string Url { get; } = url;
    public string? AltText { get; } = altText;
    public IEnumerable<ImageSizeVariation> CustomSizes { get; } = customSizes;
    
    public WebsiteImage(string url, string? altText) : this(url, altText, []) {}

    public string GetHtml(string classList = "") {
        if (CustomSizes.Any())
        {
            return $"<picture class=\"{classList}\">" +
                   string.Join("", CustomSizes.Select(size => $"<source srcset=\"{size.Src}\" media=\"(width >= {size.MinWidth}px)\">")) +
                   $"<img class=\"{classList}\" src=\"{Url}\" alt=\"{AltText ?? ""}\" />" +
                   $"</picture>";
        }
        return $"<img class=\"{classList}\" src=\"{Url}\" alt=\"{AltText ?? ""}\" />";
    }
}