namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteImage(string url, string? altText, int width, int height, IEnumerable<ImageSizeVariation> customSizes, string? label = null) : IWebsiteElement
{
    public string Url { get; } = url;
    public string? AltText { get; } = altText;
    public int Width { get; } = width;
    public int Height { get; } = height;
    public IEnumerable<ImageSizeVariation> CustomSizes { get; } = customSizes;
    public string? Label { get; } = label;
    
    public WebsiteImage(string url, string? altText = null) : this(url, altText, []) {}
    public WebsiteImage(string url, string? altText, IEnumerable<ImageSizeVariation> customSizes) : this(url, altText, 1620, 1080, customSizes) {}
    public WebsiteImage(string url, string? altText, int width, int height, string? label = null) : this(url, altText, width, height, [], label) {}

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