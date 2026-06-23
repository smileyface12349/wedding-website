namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteYouTubeVideo(string id, string title, string width, string height) : IWebsiteElement
{
    private string Id { get; } = id;
    private string Title { get; } = title;
    private string Width { get; } = width;
    private string Height { get; } = height;

    public string GetHtml(string classList = "")
    {
        return $"<iframe width={Width} height={Height} src=\"https://www.youtube.com/embed/{Id}\" title=\"{Title}\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
    }
}