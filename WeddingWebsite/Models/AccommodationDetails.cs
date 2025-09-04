using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record AccommodationDetails(
    string? Description,
    IList<Hotel> Hotels,
    WebsiteImage? Image = null
);