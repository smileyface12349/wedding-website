using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Models.ConfigInterfaces;

public interface IRsvpForm
{
    /// <summary>
    /// Questions to ask if the guest is attending.
    /// </summary>
    RsvpQuestions YesQuestions { get; }
    
    /// <summary>
    /// Questions to ask if the guest is not attending.
    /// </summary>
    RsvpQuestions NoQuestions { get; }
    
    /// <summary>
    /// RSVP deadline. This is for display purposes only - guests will still be able to RSVP after the deadline. To
    /// close RSVPs, please RSVP no for any guests that have not yet RSVPed. If there is no deadline, use null.
    /// </summary>
    DateTime? Deadline { get; }
    
    /// <summary>
    /// False: Options "Yes" and "No" in red and green boxes side by side. High-emphasis and visually distinct.
    /// True: Options "Joyfully Accept" and "Regretfully Decline", styled like a normal select field. More subtle.
    /// </summary>
    bool LongAttendanceResponses { get; }
}