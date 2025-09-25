using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models;

namespace WeddingWebsite.Services;

[Authorize (Roles = "Admin")]
public class AdminService(IStore store) : IAdminService
{
    public void AddGuestToAccount(string userId, string firstName, string lastName)
    {
        store.AddGuestToAccount(userId, firstName, lastName);
    }

    public IEnumerable<AccountWithGuests> GetAllAccounts()
    {
        return store.GetAllAccounts();
    }
    
    public IEnumerable<GuestWithId> GetGuestsForAccount(string userId)
    {
        return store.GetGuestsForAccount(userId);
    }
    
    public Guest? GetGuest(string userId, string guestId)
    {
        return store.GetGuestsForAccount(userId).FirstOrDefault(g => g.Id == guestId);
    }
    
    public void RenameGuest(string guestId, string newFirstName, string newLastName)
    {
        store.RenameGuest(guestId, newFirstName, newLastName);
    }
    
    public void DeleteGuest(string guestId)
    {
        store.DeleteGuest(guestId);
    }
}