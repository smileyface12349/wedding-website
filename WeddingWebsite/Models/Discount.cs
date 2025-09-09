namespace WeddingWebsite.Models;

public record Discount(
    int PercentDiscount,
    string ClaimInstructions
)
{
    public float CalculateDiscountedPrice(float originalPrice)
    {
        return originalPrice * (1 - PercentDiscount / 100f);
    }

    public override string ToString() {
        if (PercentDiscount <= 0)
            return "None";
        return string.IsNullOrWhiteSpace(ClaimInstructions) 
            ? $"{PercentDiscount}% off" 
            : $"{PercentDiscount}% off ({ClaimInstructions})";
    }

    public static Discount None() {
        return new Discount(0, string.Empty);
    }
};