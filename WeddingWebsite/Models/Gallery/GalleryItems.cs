using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Gallery;

/// <summary>
/// All content for the gallery section.
/// </summary>
/// <param name="Sections">Items, organised by section.</param>
/// <param name="Favourites">A selection of your favourites to go on the homepage.</param>
public record GalleryItems(IEnumerable<GallerySection> Sections, IEnumerable<BigGalleryItem> Favourites)
{
    public GalleryItems(IEnumerable<GallerySection> sections) : this(sections, []) {}
    
    public GalleryItems(IEnumerable<BigGalleryItem> favourites) : this ([], favourites) {}
}