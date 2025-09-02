namespace WeddingWebsite.Models;

public record AccommodationDetails(
    string? Description,
    IList<Hotel> Hotels
);