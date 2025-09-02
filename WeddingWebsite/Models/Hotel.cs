namespace WeddingWebsite.Models;

public record Hotel (
    string Name,
    Location Location,
    string Address,
    int DrivingTimeFromVenueMinutes,
    int ApproximatePrice,
    Discount Discount
);