using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Services;

[Authorize]
public class RegistryService(IRegistryStore registryStore) : IRegistryService
{
    [Authorize(Roles = "Admin")]
    public void AddItem(RegistryItem item) => registryStore.AddItem(item);
    
    [Authorize(Roles = "Admin")]
    public void UpdateItem(RegistryItem item) => registryStore.UpdateItem(item);
    
    [Authorize(Roles = "Admin")]
    public bool DeleteItem(string itemId) => registryStore.DeleteItem(itemId);
    
    public RegistryItem? GetRegistryItemById(string itemId) => registryStore.GetRegistryItemById(itemId);
    
    public Task<IEnumerable<RegistryItem>> GetAllRegistryItems(bool includeHidden = false) => registryStore.GetAllRegistryItems(includeHidden);
    
    public bool ClaimRegistryItem(string itemId, string userId, int quantity = 1) => registryStore.ClaimRegistryItem(itemId, userId, quantity);
    
    public bool UnclaimRegistryItem(string itemId, string userId) => registryStore.UnclaimRegistryItem(itemId, userId);
    
    public void ChoosePurchaseMethod(string itemId, string userId, string? purchaseMethodId) => registryStore.ChoosePurchaseMethod(itemId, userId, purchaseMethodId);
    
    public void ChooseDeliveryAddress(string itemId, string userId, string? address) => registryStore.ChooseDeliveryAddress(itemId, userId, address);
    
    public void MarkClaimAsCompleted(string itemId, string userId) => registryStore.MarkClaimAsCompleted(itemId, userId);
    
    [Authorize(Roles = "Admin")]
    public void MarkClaimAsNotCompleted(string itemId, string userId) => registryStore.MarkClaimAsNotCompleted(itemId, userId);
}