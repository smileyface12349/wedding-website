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
    
    public record None : Discount
    {
        public None() : base(0, string.Empty) { }
    }
};