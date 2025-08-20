namespace WeddingWebsite.Models;

public record Hotel (
    string Name,
    Location Location,
    string Address,
    int ApproximatePrice,
    Discount? Discount
);