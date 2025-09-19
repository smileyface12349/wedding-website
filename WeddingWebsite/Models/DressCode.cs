using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record DressCode(
    string Title,
    IEnumerable<WebsiteSection> Content,
    IWebsiteElement? Media = null
)
{
    public DressCode(string title, string content, IWebsiteElement? media = null) 
        : this(title, [new WebsiteSection(null, content)], media) {}
}