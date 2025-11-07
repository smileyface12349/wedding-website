using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Accommodation;

public record Hotel (
    string Name,
    string Description,
    Location Location,
    string Address,
    int DrivingTimeFromVenueMinutes,
    int ApproximatePrice,
    Discount Discount,
    string Link,
    bool Emphasise = false,
    IWebsiteElement? Media = null
)
{
    public string PriceString {
        get {
            if (Discount.PercentDiscount == 0) {
                return $"£{ApproximatePrice}";
            } else {
                return $"Full Price: £{ApproximatePrice}, With Discount: £{Discount.CalculateDiscountedPrice(ApproximatePrice)} ({Discount.ClaimInstructions})";
            }
        }
    }
    
    public int DiscountedPrice => (int) Discount.CalculateDiscountedPrice(ApproximatePrice);
}