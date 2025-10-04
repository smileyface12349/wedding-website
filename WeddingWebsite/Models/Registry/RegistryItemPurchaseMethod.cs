namespace WeddingWebsite.Models.Registry;

public record RegistryItemPurchaseMethod(
    string Id,
    string Name,
    double Cost,
    bool AllowBringOnDay = true,
    bool AllowDeliverToUs = true,
    string? Url = null,
    string? Instructions = null,
    double DeliveryCost = 0
);