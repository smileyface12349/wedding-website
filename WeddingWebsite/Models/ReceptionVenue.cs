namespace WeddingWebsite.Models;

public record ReceptionVenue(
    string Name,
    Location Location,
    string Address,
    TravelDirections? Directions
) : IVenue;