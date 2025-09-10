using System.ComponentModel.DataAnnotations;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WeddingDetails;

public static class WeddingDetailsValidator
{
    public static void Validate(this IWeddingDetails details) {
        ThereIsABrideAndGroom(details);
        Events_IsNotEmpty(details);
        Events_DoNotReturnToSameVenueTwice(details);
        Events_EarliestStartTimeIsFirstEvent(details);
        Events_LatestFinishTimeIsLastEvent(details);
    }
    
    /// <summary>
    /// A bride and groom are required for the homepage where it displays their names
    /// </summary>
    private static void ThereIsABrideAndGroom(IWeddingDetails details) {
        if (details.NotablePeople.All(p => p.Role != Role.Bride)) {
            throw new ValidationException("There is no bride in the notable people list. This is required for");
        }
        if (details.NotablePeople.All(p => p.Role != Role.Groom)) {
            throw new ValidationException("There is no groom in the notable people list.");
        }
    }
    
    /// <summary>
    /// If there are no events, the timeline will not work properly.
    /// The countdown relies on the start time of the first event
    /// </summary>
    private static void Events_IsNotEmpty(IWeddingDetails details) {
        if (!details.Events.Any()) {
            throw new ValidationException("There are no events in the wedding details.");
        }
    }
    
    /// <summary>
    /// Returning to the same venue will show the same travel directions.
    /// This constraint can be relaxed with a little extra coding to handle different travel directions based on origin.
    /// </summary>
    private static void Events_DoNotReturnToSameVenueTwice(IWeddingDetails details) {
        var visited = new HashSet<string>();
        string? currentVenue = null;
        foreach (var ev in details.Events)
        {
            if (ev.Venue.Name == currentVenue) {
                continue;
            }
            if (visited.Contains(ev.Venue.Name)) {
                throw new ValidationException($"The venue {ev.Venue.Name} is visited in two different events from different locations. This is not currently supported.");
            }
            visited.Add(ev.Venue.Name);
        }
    }
    
    /// <summary>
    /// This assumption is made when determining the start time in the countdown timer.
    /// </summary>
    private static void Events_EarliestStartTimeIsFirstEvent(IWeddingDetails details) {
        var firstStartTime = details.Events.First().Start;
        if (details.Events.Any(e => e.Start < firstStartTime)) {
            throw new ValidationException("The earliest start time must be the first element in the list");
        }
    }
    
    /// <summary>
    /// This assumption is made when determining the time to show alongside the accommodation details.
    /// </summary>
    private static void Events_LatestFinishTimeIsLastEvent(IWeddingDetails details) {
        var lastFinishTime = details.Events.Last().End;
        if (lastFinishTime == null) {
            // An unspecified end time is a valid state
            return;
        }
        if (details.Events.Any(e => e.End != null && e.End > lastFinishTime)) {
            throw new ValidationException("The latest finish time must be the last element in the list");
        }
    }
}