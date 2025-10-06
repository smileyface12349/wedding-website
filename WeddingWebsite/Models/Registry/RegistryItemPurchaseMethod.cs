namespace WeddingWebsite.Models.Registry;

public record RegistryItemPurchaseMethod(
    string Id,
    string Name,
    decimal Cost,
    bool AllowBringOnDay = true,
    bool AllowDeliverToUs = true,
    string? Url = null,
    string? Instructions = null,
    decimal DeliveryCost = 0
);