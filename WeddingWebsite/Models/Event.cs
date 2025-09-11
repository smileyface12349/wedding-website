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
    IEnumerable<WebsiteSection> Description,
    Venue Venue,
    WebsiteImage? Image,
    string? Icon,
    IEnumerable<WeddingModal> Modals
)
{
    /// <summary>
    /// Simple description, no modals
    /// </summary>
    public Event(string name, TimeOnly start, TimeOnly? end, string description, Venue venue, WebsiteImage? image = null, string? icon = null) 
        : this(name, start, end, [new WebsiteSection(null, description)], venue, image, icon, new List<WeddingModal>()) {}
        
    /// <summary>
    /// Simple description, modals
    /// </summary>
    public Event(string name, TimeOnly start, TimeOnly? end, string description, Venue venue, WebsiteImage? image, string? icon, IEnumerable<WeddingModal> modals) 
        : this(name, start, end, [new WebsiteSection(null, description)], venue, image, icon, modals) {}
}