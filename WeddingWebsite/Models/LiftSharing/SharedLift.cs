namespace WeddingWebsite.Models.LiftSharing;

public record SharedLift(
    string Id,
    string UserId,
    string UserEmail,
    string Name,
    int Spaces,
    int NumBookings,
    JourneyEndpoint Start,
    JourneyEndpoint End,
    string Notes = ""
) : ISharedLift
{
    public int AvailableSpaces => Spaces - NumBookings;
}