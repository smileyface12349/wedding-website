using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.LiftSharing;

namespace WeddingWebsite.Services;

public class LiftSharingService(ILiftSharingStore store) : ILiftSharingService
{
    public void AddLift(string userId, string name, int spaces, Journey journey, string notes)
    {
        var lift = new SharedLift(
            Id: Guid.NewGuid().ToString(),
            UserId: userId,
            UserEmail: "unused",
            Name: name,
            Spaces: spaces,
            NumBookings: 0,
            Start: journey.Start,
            End: journey.End,
            Notes: notes
        );
        
        store.AddLift(lift);
    }

    public IEnumerable<ISharedLift> GetAllLifts()
    {
        return store.GetAllLifts();
    }
}