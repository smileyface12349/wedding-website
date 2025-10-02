using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Gallery;

/// <summary>
/// All content for the gallery section.
/// </summary>
/// <param name="Items">Items, organised by section.</param>
public record GalleryItems(IEnumerable<GallerySection> Sections);