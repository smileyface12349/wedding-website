using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record DressCode(
    string Title,
    string Description,
    IWebsiteElement? Media = null 
);