using WeddingWebsite.Data.Models;

namespace WeddingWebsite.Data.Stores;

public interface IRsvpStore
{
    /// <summary>
    /// Submit an RSVP for the given user. Data is a list of length 21 (or fewer), with each position containing the
    /// data to go in that position (e.g. index 0 goes in column "Data0"). The data columns correspond to the yes forms
    /// and the no forms, and it's important that data is stored in the right place for the corresponding form.
    /// Returns false if the user has already RSVPed.
    /// </summary>
    bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> rsvpData);
    
    /// <summary>
    /// Get the RSVP response for a given user. Returns null if the user has not RSVPed. Note that this method does not
    /// make any effort to match up the data to questions.
    /// </summary>
    RsvpResponseData? GetRsvp(string guestId);
    
    /// <summary>
    /// Retrieve all RSVPs. Note that this method does not make any effort to match up the data to questions.
    /// </summary>
    IEnumerable<RsvpResponseData> GetAllRsvps();
    
    /// <summary>
    /// Delete the RSVP for a given user. Should be restricted to admins only.
    /// </summary>
    void DeleteRsvp(string guestId);
}