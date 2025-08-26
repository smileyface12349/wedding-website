namespace WeddingWebsite.Models.Venues;

public record ReceptionVenue(
    string Name,
    Location Location,
    string Address,
    TravelDirections? Directions
) : IVenue;