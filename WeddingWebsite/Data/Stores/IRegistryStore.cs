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
    /// Choose a fulfillment method (i.e. bring on day, deliver to us, or money transfer)
    /// </summary>
    void ChooseFulfillmentMethod(string itemId, string userId, FulfillmentMethod? fulfillmentMethod);
    
    /// <summary>
    /// Choose a recipient. Used for delivery address or bank details.
    /// </summary>
    void ChooseRecipient(string itemId, string userId, string? recipient);
    
    /// <summary>
    /// Marks the claim as completed. Completed claims cannot be deleted. Only admins can 'uncomplete' claims.
    /// </summary>
    void MarkClaimAsCompleted(string itemId, string userId);
    
    /// <summary>
    /// This should be restricted to admin users only.
    /// </summary>
    void MarkClaimAsNotCompleted(string itemId, string userId);
    
    /// <summary>
    /// Marks it as received, which is visible to admins only and can only be done by admins.
    /// </summary>
    void MarkClaimAsReceived(string itemId, string userId);
    
    /// <summary>
    /// Undo marking it as received, because everyone can make mistakes, even admins.
    /// </summary>
    void MarkClaimAsNotReceived(string itemId, string userId);
    
    /// <summary>
    /// Set notes for the claim. It's entirely up to the purchaser what they want to put here, if anything at all.
    /// </summary>
    void SetClaimNotes(string itemId, string userId, string? notes);
    
    /// <summary>
    /// Update an existing claim. For admins only - user flow is done through more restrictive methods.
    /// </summary>
    void UpdateClaim(string itemId, string oldUserId, string newUserId, FulfillmentMethod? newFulfillmentMethod, string? newRecipient, int newQuantity, string? newNotes);
}