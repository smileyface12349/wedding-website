namespace WeddingWebsite.Models.Registry;

public record RegistryItem(
    string Id,
    string GenericName,
    string Name,
    string? Description,
    string? ImageUrl,
    IEnumerable<RegistryItemPurchaseMethod> PurchaseMethods,
    IEnumerable<RegistryItemClaim> Claims,
    int MaxQuantity = 1,
    int Priority = 0,
    bool Hide = false
)
{
    public int QuantityClaimed => Claims.Sum(c => c.Quantity);
    public bool IsFullyClaimed => QuantityClaimed >= MaxQuantity;
    public double CheapestCost => PurchaseMethods.Min(pm => pm.Cost);
}