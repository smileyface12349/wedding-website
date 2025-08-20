namespace WeddingWebsite.Models;

public record Event(
    string Name,
    DateTime Start,
    DateTime? End,
    string Description,
    IVenue Venue
);