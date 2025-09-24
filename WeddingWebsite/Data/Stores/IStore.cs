using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;

namespace WeddingWebsite.Data.Stores;

public interface IStore
{
    /// <summary>
    /// Retrieve all guests associated with a specific user. Each guest is associated with exactly one user.
    /// </summary>
    public IEnumerable<GuestResponse> GetGuestsForUser(string userId);
}