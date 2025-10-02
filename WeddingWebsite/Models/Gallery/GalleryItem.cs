using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Gallery;

public record GalleryItem(WebsiteImage Image)
{
    /// <summary>
    /// Create a gallery item with a URL image and no alt text.
    /// </summary>
    public GalleryItem(string url) : this(new WebsiteImage(url, null)) {}
}