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
    
    public void RenameLift(string liftId, string newName)
    {
        store.RenameLift(liftId, newName);
    }
    
    public bool ChangeSpaces(string liftId, int newSpaces)
    {
        return store.ChangeSpaces(liftId, newSpaces);
    }
    
    public bool DeleteLift(string liftId)
    {
        return store.DeleteLift(liftId);
    }

    public IEnumerable<ISharedLift> GetAllLifts()
    {
        return store.GetAllLifts();
    }

    public SharedLiftWithBookings? GetLift(string liftId)
    {
        return store.GetLift(liftId);
    }
    
    public string? GetGuestBooking(string userId, string guestId)
    {
        return store.GetGuestBooking(userId, guestId);
    }
    
    public bool BookLift(string liftId, string userId, string nameOrGuestId, bool isGuest)
    {
        if (isGuest)
        {
            return store.BookLiftGuest(liftId, userId, nameOrGuestId);
        }
        else
        {
            return store.BookLiftNonGuest(liftId, userId, nameOrGuestId);
        }
    }

    public void RemoveBooking(string liftId, string userId, string name, string? guestId)
    {
        if (guestId != null)
        {
            store.CancelGuestBooking(userId, guestId);
        }
        else
        {
            store.CancelNonGuestBooking(userId, name);
        }
    }
}