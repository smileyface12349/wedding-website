using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Venues;

/// <summary>
/// Instructions for how to get somewhere. Doesn't contain the actual address or location.
/// </summary>
/// <param name="Content">Sections and paragraphs of instructions.</param>
/// <param name="CustomDescription">A short description before viewing directions. If null, one is auto-generated.</param>
/// <param name="DrivingTimeInMinutes">How long it takes to drive. Used in the default description.</param>
/// <param name="CoverImage">A cover image, used in the timeline for the travel directions step.</param>
/// <param name="Media">Used in the directions section only.</param>
public record TravelDirections(
    IEnumerable<WebsiteSection> Content,
    string? CustomDescription = null,
    int? DrivingTimeInMinutes = null,
    WebsiteImage? CoverImage = null,
    IWebsiteElement? Media = null
)
{
    public TravelDirections(string content, string? customDescription = null, int? drivingTimeInMinutes = null, WebsiteImage? coverImage = null) 
        : this([new WebsiteSection(null, content)], customDescription, drivingTimeInMinutes, coverImage) {}
        
    public string Description => CustomDescription ?? (DrivingTimeInMinutes.HasValue 
        ? $"{DrivingTimeInMinutes} min drive." 
        : "Click below for travel directions");
}