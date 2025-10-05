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
    public decimal CheapestCost => PurchaseMethods.Min(pm => pm.Cost);
    
    public int NumClaimsByUser(string userId)
    {
        return Claims.Where(c => c.UserId == userId).Sum(c => c.Quantity);
    }
    
    /// <summary>
    /// Gets the unique claim for the specified user. Throws if there is no such claim.
    /// </summary>
    public RegistryItemClaim GetClaimByUser(string userId)
    {
        return Claims.Single(c => c.UserId == userId);
    }

    /// <summary>
    /// Gets the purchase method that the user has selected. Throws if the user hasn't selected a purchase method.
    /// </summary>
    public RegistryItemPurchaseMethod GetPurchaseMethodByUser(string userId)
    {
        var claim = GetClaimByUser(userId);
        return PurchaseMethods.Single(pm => pm.Id == claim.PurchaseMethodId);
    }
}