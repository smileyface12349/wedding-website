namespace WeddingWebsite.Models.LiftSharing;

public interface ISharedLift
{
    string Id { get; }
    string UserId { get; }
    string? UserEmail { get; }
    string Name { get; }
    int Spaces { get; }
    int AvailableSpaces { get; }
    JourneyEndpoint Start { get; }
    JourneyEndpoint End { get; }
    string Notes { get; }
}