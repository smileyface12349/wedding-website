using WeddingWebsite.Models.LiftSharing;

namespace WeddingWebsite.Services;

public interface ILiftSharingService
{
    void AddLift(string userId, string name, int spaces, Journey journey, string notes);
    IEnumerable<ISharedLift> GetAllLifts();
    SharedLiftWithBookings? GetLift(string liftId);
    string? GetGuestBooking(string userId, string guestId);
    bool BookLift(string liftId, string userId, string nameOrGuestId, bool isGuest);
    void RemoveBooking(string liftId, string userId, string name, string? guestId);
}