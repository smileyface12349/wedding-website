using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Gallery;

/// <summary>
/// A gallery item for the section on the homepage, which also includes an optional title and description.
/// </summary>
/// <param name="Image">The image</param>
/// <param name="Credit">(Optional) E.g. "Credit: John Smith". A bit less invasive than the description.</param>
/// <param name="Title">(Optional) Title (you can still specify description without a title)</param>
/// <param name="Description">(Optional) Description</param>
public record BigGalleryItem(
    WebsiteImage Image,
    string Credit = "",
    string Title = "", 
    string Description = ""
);