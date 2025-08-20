namespace WeddingWebsite.Models;

public record CeremonyVenue(
    string Name,
    Location Location,
    string Address,
    TravelDirections Directions
) : IVenue;