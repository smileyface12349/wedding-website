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
    
    public void ChooseFulfillmentMethod(string itemId, string userId, FulfillmentMethod? fulfillmentMethod) => registryStore.ChooseFulfillmentMethod(itemId, userId, fulfillmentMethod);
    
    public void ChooseRecipient(string itemId, string userId, string? recipient) => registryStore.ChooseRecipient(itemId, userId, recipient);
    
    public void MarkClaimAsCompleted(string itemId, string userId) => registryStore.MarkClaimAsCompleted(itemId, userId);
    
    [Authorize(Roles = "Admin")]
    public void MarkClaimAsNotCompleted(string itemId, string userId) => registryStore.MarkClaimAsNotCompleted(itemId, userId);
    
    public void SetClaimNotes(string itemId, string userId, string? notes) => registryStore.SetClaimNotes(itemId, userId, notes);
}