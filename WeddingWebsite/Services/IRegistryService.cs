using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Services;

public interface IRegistryService
{
    void AddItem(RegistryItem item);
    void UpdateItem(RegistryItem item);
    bool DeleteItem(string itemId);
    RegistryItem? GetRegistryItemById(string itemId);
    Task<IEnumerable<RegistryItem>> GetAllRegistryItems(bool includeHidden = false);
    bool ClaimRegistryItem(string itemId, string userId, int quantity = 1);
    bool UnclaimRegistryItem(string itemId, string userId);
    void ChoosePurchaseMethod(string itemId, string userId, string? purchaseMethodId);
    void ChooseDeliveryAddress(string itemId, string userId, string? address);
    void MarkClaimAsCompleted(string itemId, string userId);
    void MarkClaimAsNotCompleted(string itemId, string userId);
    
}