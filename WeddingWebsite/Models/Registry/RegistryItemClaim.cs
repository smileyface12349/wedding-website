namespace WeddingWebsite.Models.Registry;

public record RegistryItemClaim(
    string ItemId,
    string UserId,
    FulfillmentMethod? FulfillmentMethod,
    string? Recipient,
    DateTime ClaimedAt,
    DateTime? CompletedAt,
    DateTime? ReceivedAt,
    int Quantity,
    string? Notes
)
{
    public bool IsCompleted => CompletedAt != null;
    public bool IsReceived => ReceivedAt != null;
}