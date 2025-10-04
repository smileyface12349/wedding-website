using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Data.Stores;

public interface IRegistryStore
{
    /// <summary>
    /// Add a new registry item.
    /// </summary>
    void AddItem(RegistryItem item);
    
    /// <summary>
    /// Matches by the id, then updates every single other field in the object, including purchase methods. Doesn't do
    /// anything to the claims.
    /// </summary>
    void UpdateItem(RegistryItem item);
    
    /// <summary>
    /// Delete the item with the given id, along with all associated purchase methods and claims.
    /// </summary>
    bool DeleteItem(string itemId);
    
    /// <summary>
    /// Gets registry item by its ID, or null if not found.
    /// </summary>
    RegistryItem? GetRegistryItemById(string itemId);
    
    /// <summary>
    /// Obtain every single registry item, ordered by priority (highest first). This must be done asynchronously.
    /// </summary>
    Task<IEnumerable<RegistryItem>> GetAllRegistryItems(bool includeHidden = false);
    
    /// <summary>
    /// Registers a claim on the given item by the given purchaser. Returns false if the number of claims would exceed
    /// the max quantity. Throws if the item does not exist.
    /// </summary>
    bool ClaimRegistryItem(string itemId, string userId, int quantity = 1);
    
    /// <summary>
    /// Removes the claim on the given item by the given purchaser. This may include a quantity greater than one.
    /// Throws if no such claim exists. Returns false if the claim has already been marked as 'completed'.
    /// </summary>
    bool UnclaimRegistryItem(string itemId, string userId);
    
    /// <summary>
    /// Choose a purchase method for this claim. Throws if no such claim exists. This is a prerequisite for marking
    /// the claim as completed.
    /// </summary>
    void ChoosePurchaseMethod(string itemId, string userId, string? purchaseMethodId);
    
    /// <summary>
    /// Choose a delivery address. This is required if the purchase method allows bringing to venue or delivery to us.
    /// If the purchase method does not allow either, this doesn't need to be called before marking as completed.
    /// </summary>
    void ChooseDeliveryAddress(string itemId, string userId, string? address);
    
    /// <summary>
    /// Marks the claim as completed. Completed claims cannot be deleted. Only admins can 'uncomplete' claims.
    /// </summary>
    void MarkClaimAsCompleted(string itemId, string userId);
    
    /// <summary>
    /// This should be restricted to admin users only.
    /// </summary>
    void MarkClaimAsNotCompleted(string itemId, string userId);
}