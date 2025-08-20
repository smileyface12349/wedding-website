namespace WeddingWebsite.Models;

public record AccommodationDetails(
    string? Description,
    Hotel? RecommendedHotel,
    IEnumerable<Hotel> OtherHotels
);