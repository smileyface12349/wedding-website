using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record TravelDirections(
    string Message,
    string Parking,
    IWebsiteElement? Media = null
);