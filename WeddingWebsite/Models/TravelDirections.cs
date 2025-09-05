using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record TravelDirections(
    string HtmlContent,
    int? DrivingTimeInMinutes = null,
    WebsiteImage? CoverImage = null
);