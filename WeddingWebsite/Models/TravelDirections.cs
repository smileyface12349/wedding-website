using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record TravelDirections(
    IEnumerable<WebsiteSection> Content,
    int? DrivingTimeInMinutes = null,
    WebsiteImage? CoverImage = null
)
{
    public TravelDirections(string content, int? drivingTimeInMinutes = null, WebsiteImage? coverImage = null) 
        : this([new WebsiteSection(null, content)], drivingTimeInMinutes, coverImage) {}
}