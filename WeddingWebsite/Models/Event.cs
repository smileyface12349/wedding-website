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
    IVenue Venue
);