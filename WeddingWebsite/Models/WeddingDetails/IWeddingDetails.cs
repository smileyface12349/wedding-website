using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WeddingDetails;

public interface IWeddingDetails
{
    /// <summary>
    /// Noteworthy people involved with the wedding. This should include:
    /// <br/> - Bride and Groom.
    /// <br/> - Bridesmaids and Groomsmen (for 'meet the wedding party').
    /// <br/> - Anyone you want to list as a contact.
    /// <br/>Other people added will not do any harm, but won't be visible on the website.
    /// </summary>
    public IEnumerable<NotablePerson> NotablePeople { get; }
    
    /// <summary>
    /// Any additional contacts that aren't in NotablePeople. Do not include any contacts already in NotablePeople -
    /// these have been added already, and will be duplicated if you include them here too. This is only recommended
    /// for shared mailboxes and anything which isn't a person, as people should be added to NotablePeople instead.
    /// </summary>
    public IEnumerable<IContact> ExtraContacts { get; }
    
    /// <summary>
    /// The date of the wedding. Weddings spanning multiple dates are currently unsupported.
    /// </summary>
    public DateOnly WeddingDate { get; }
    
    /// <summary>
    /// A list of stuff that's happening. This should be in chronological order with no gaps, except for travel.
    /// </summary>
    public IEnumerable<Event> Events { get; }
    
    /// <summary>
    /// The dress code. Used in the dress code section.
    /// </summary>
    public DressCode DressCode { get; }
    
    /// <summary>
    /// Accommodation details, used to generate an event at the end of the timeline.
    /// </summary>
    public AccommodationDetails AccommodationDetails { get; }
    
    /// <summary>
    /// The main image is used at the top of the homepage and as the background for the login page. It is accessible
    /// to unauthenticated users.
    /// </summary>
    public WebsiteImage MainImage { get; }
    
    // Helper methods
    public IPerson Groom => NotablePeople.FirstOrDefault(p => p.Role == Role.Groom) ?? new NotablePerson(new Name("Blank", "Groom"), Role.Groom);
    public IPerson Bride => NotablePeople.FirstOrDefault(p => p.Role == Role.Bride) ?? new NotablePerson(new Name("Blank", "Bride"), Role.Bride);
    public IContactMethod? LoginContactMethod => NotablePeople.Concat(ExtraContacts).Select(p => p.ContactDetails.NotUrgent).FirstOrDefault(p => p.MatchesReason(ContactReason.Website))?.Methods.FirstOrDefault() 
                                                 ?? NotablePeople.Concat(ExtraContacts).Select(p => p.ContactDetails.Urgent).FirstOrDefault(p => p.MatchesReason(ContactReason.Website))?.Methods.FirstOrDefault();
}