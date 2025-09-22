using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Used for the "how we met" section.
/// </summary>
/// <param name="Content">Array of paragraphs</param>
/// <param name="BrideImage">If null, no image is shown. Consider using Bride.Media.</param>
/// <param name="GroomImage">If null, no image is shown. Consider using Groom.Media.</param>
public sealed record Backstory(string[] Content, IWebsiteElement? BrideImage, IWebsiteElement? GroomImage)
{
    public Backstory(string Content, IWebsiteElement? BrideImage, IWebsiteElement? GroomImage) 
        : this([Content], BrideImage, GroomImage) {}
}