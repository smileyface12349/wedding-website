using WeddingWebsite.Models.LiftSharing;

namespace WeddingWebsite.Services;

public interface ILiftSharingService
{
    void AddLift(string userId, string name, int spaces, Journey journey, string notes);
    void RenameLift(string liftId, string newName);
    bool ChangeSpaces(string liftId, int newSpaces);
    void ChangeLiftNotes(string liftId, string newNotes);
    bool DeleteLift(string liftId);
    IEnumerable<ISharedLift> GetAllLifts();
    SharedLiftWithBookings? GetLift(string liftId);
    string? GetGuestBooking(string userId, string guestId);
    IEnumerable<SharedLiftWithBookings> GetAllBookings(string userId);
    bool BookLift(string liftId, string userId, string nameOrGuestId, bool isGuest);
    void RemoveBooking(string userId, string name, string? guestId);
    IEnumerable<SharedLiftBooking> GetAllLiftRequests();
    void AssignLift(string userId, string name, string? guestId, string liftId);
    void RequestLift(string userId, string name, string? guestId);
}