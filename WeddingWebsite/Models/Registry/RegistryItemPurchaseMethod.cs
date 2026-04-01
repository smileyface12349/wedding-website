namespace WeddingWebsite.Models.Registry;

public record RegistryItemPurchaseMethod(
    string Id,
    string Name,
    decimal Cost,
    string? Url = null,
    decimal DeliveryCost = 0
);