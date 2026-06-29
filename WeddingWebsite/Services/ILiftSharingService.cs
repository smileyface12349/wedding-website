using WeddingWebsite.Models.LiftSharing;

namespace WeddingWebsite.Services;

public interface ILiftSharingService
{
    void AddLift(string userId, string name, int spaces, Journey journey, string notes);
    IEnumerable<ISharedLift> GetAllLifts();
}