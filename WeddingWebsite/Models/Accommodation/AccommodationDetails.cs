using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Accommodation;

public record AccommodationDetails(
    string? Description,
    IList<Hotel> Hotels,
    WebsiteImage? Image = null
);