using WeddingWebsite.Models.LiftSharing;
using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Data.Stores;

public interface ILiftSharingStore
{
    void AddLift(ISharedLift lift);
    void RenameLift(string id, string newName);
    bool ChangeSpaces(string id, int newSpaces);
    void ChangeLiftNotes(string id, string newNotes);
    bool DeleteLift(string id);
    SharedLiftWithBookings? GetLift(string id);
    IEnumerable<ISharedLift> GetAllLifts();
    string? GetGuestBooking(string userId, string guestId);
    IEnumerable<string> GetBookedLifts(string userId);
    bool BookLiftGuest(string liftId, string userId, string guestId);
    bool BookLiftNonGuest(string liftId, string userId, string name);
    void CancelGuestBooking(string userId, string guestId);
    void CancelNonGuestBooking(string userId, string name);
    bool RequestLiftGuest(string userId, string guestId);
    bool RequestLiftNonGuest(string userId, string name);
    IEnumerable<SharedLiftBooking> GetAllLiftRequests();
    bool AssignLiftGuest(string userId, string guestId, string liftId);
    bool AssignLiftNonGuest(string userId, string guestId, string liftId);
}