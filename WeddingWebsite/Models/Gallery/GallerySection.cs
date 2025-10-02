namespace WeddingWebsite.Models.Gallery;

public record GallerySection(
    IEnumerable<GalleryItem> Items, 
    string? Title = null,
    string? Description = null
);