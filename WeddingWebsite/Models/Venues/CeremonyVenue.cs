namespace WeddingWebsite.Models.Venues;

public record CeremonyVenue(
    string Name,
    Location Location,
    string Address,
    TravelDirections Directions
) : IVenue;