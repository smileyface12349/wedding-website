namespace WeddingWebsite.Models;

public record Discount(
    int PercentDiscount,
    string ClaimInstructions
)
{
    float CalculateDiscountedPrice(float originalPrice)
    {
        return originalPrice * (1 - PercentDiscount / 100f);
    }
};