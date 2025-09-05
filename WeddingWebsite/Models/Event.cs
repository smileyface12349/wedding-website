using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models;

/// <summary>
/// Something to display in the "order of the day".
/// Note that we are assuming all events take place on the day of the wedding.
/// </summary>
public record Event(
    string Name,
    TimeOnly Start,
    TimeOnly? End,
    string Description,
    IVenue Venue,
    WebsiteImage? Image,
    string? Icon,
    IEnumerable<WeddingModal> Modals
)
{
    /// <summary>
    /// Secondary constructor to make modals optional
    /// </summary>
    public Event(string name, TimeOnly start, TimeOnly? end, string description, IVenue venue, WebsiteImage? image = null, string? icon = null) 
        : this(name, start, end, description, venue, image, icon, new List<WeddingModal>()) {}
}