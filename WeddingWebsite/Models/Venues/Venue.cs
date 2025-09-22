using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Venues;

/// <summary>
/// A venue that stuff happens in.
/// </summary>
/// <param name="Name">Needs to uniquely identify the venue</param>
/// <param name="Location">Used in travel directions modal.</param>
/// <param name="Address">Used in timeline (travel directions modal only) and venue showcase.</param>
/// <param name="Directions">Used in timeline and venue showcase.</param>
/// <param name="Description">Used in venue showcase only.</param>
/// <param name="Media">Used in venue showcase only.</param>
/// <param name="Modals">Used in venue showcase only.</param>
public record Venue(string Name, Location Location, string Address, TravelDirections? Directions, string? Description, IWebsiteElement? Media, IEnumerable<WeddingModal> Modals)
{
    /// <summary>
    /// Default with no modals.
    /// </summary>
    public Venue(string Name, Location Location, string Address, TravelDirections? Directions = null, string? Description = null, IWebsiteElement? Media = null) 
        : this(Name, Location, Address, Directions, Description, Media, []) {}
}