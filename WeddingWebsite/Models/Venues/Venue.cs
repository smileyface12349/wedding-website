using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Venues;

/// <summary>
/// A venue that stuff happens in.
/// </summary>
public record Venue (string Name, Location Location, string Address, TravelDirections? Directions = null, IWebsiteElement? Media = null);