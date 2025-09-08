using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

public record TravelDirections(
    IEnumerable<WebsiteSection> Content,
    string? CustomDescription = null,
    int? DrivingTimeInMinutes = null,
    WebsiteImage? CoverImage = null
)
{
    public TravelDirections(string content, string? customDescription = null, int? drivingTimeInMinutes = null, WebsiteImage? coverImage = null) 
        : this([new WebsiteSection(null, content)], customDescription, drivingTimeInMinutes, coverImage) {}
        
    public string Description => CustomDescription ?? (DrivingTimeInMinutes.HasValue 
        ? $"{DrivingTimeInMinutes} min drive." 
        : "Click below for travel directions");
}