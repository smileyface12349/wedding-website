using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Gallery;

public record GalleryItem(WebsiteImage Image, int Size = 1);