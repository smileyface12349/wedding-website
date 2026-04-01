namespace WeddingWebsite.Models.Registry;

public record RegistryItem(
    string Id,
    string GenericName,
    string Name,
    string? Description,
    string? ImageUrl,
    decimal Cost,
    IEnumerable<RegistryItemPurchaseMethod> PurchaseMethods,
    IEnumerable<RegistryItemClaim> Claims,
    int MaxQuantity = 1,
    int Priority = 0,
    bool Hide = false,
    bool AllowBringOnDay = false,
    bool AllowDeliverToUs = false,
    bool AllowMoneyTransfer = false
)
{
    public int QuantityClaimed => Claims.Sum(c => c.Quantity);
    public bool IsFullyClaimed => QuantityClaimed >= MaxQuantity;

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

    public IEnumerable<FulfillmentMethod> GetAllowedFulfillmentMethods()
    {
        var methods = new List<FulfillmentMethod>();
        if (AllowBringOnDay) methods.Add(FulfillmentMethod.BringOnDay);
        if (AllowDeliverToUs) methods.Add(FulfillmentMethod.DeliverToUs);
        if (AllowMoneyTransfer) methods.Add(FulfillmentMethod.TransferMoney);
        return methods;
    }
}