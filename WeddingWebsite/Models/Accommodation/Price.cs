namespace WeddingWebsite.Models.Accommodation;

public record Price(
    decimal Amount,
    Discount Discount,
    string? CustomString = null
)
{
    public Price(decimal amount) : this(amount, Discount.None()) {}

    public override string ToString() {
        if (CustomString != null) {
            return CustomString;
        } else if (Discount.PercentDiscount == 0) {
            return $"£{Amount}";
        } else {
            return $"Full Price: £{Amount}, With Discount: £{Discount.CalculateDiscountedPrice((float) Amount)} ({Discount.ClaimInstructions})";
        }
    }
    
    public float DiscountedPrice => Discount.CalculateDiscountedPrice((float) Amount);
}