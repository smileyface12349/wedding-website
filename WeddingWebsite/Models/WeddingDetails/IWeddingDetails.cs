using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WeddingDetails;

public interface IWeddingDetails
{
    // Information about the Wedding
    public IEnumerable<NotablePerson> NotablePeople { get; }
    public IEnumerable<IContact> ExtraContacts { get; }
    public DateOnly WeddingDate { get; }
    public IEnumerable<Event> Events { get; }
    public DressCode DressCode { get; }
    public AccommodationDetails AccommodationDetails { get; }
    
    // Static Files and External Links
    public WebsiteImage MainImage { get; }
    public IEnumerable<WebsiteImage> GalleryImages { get; }
    public WebsiteLink RegistryLink { get; }
    
    // Helper methods
    public IPerson Groom => NotablePeople.FirstOrDefault(p => p.Role == Role.Groom) ?? new NotablePerson(new Name("Blank", "Groom"), Role.Groom);
    public IPerson Bride => NotablePeople.FirstOrDefault(p => p.Role == Role.Bride) ?? new NotablePerson(new Name("Blank", "Bride"), Role.Bride);
    public IContactMethod? LoginContactMethod => NotablePeople.Concat(ExtraContacts).Select(p => p.ContactDetails.NotUrgent).FirstOrDefault(p => p.MatchesReason(ContactReason.Website))?.Methods.FirstOrDefault() 
                                                 ?? NotablePeople.Concat(ExtraContacts).Select(p => p.ContactDetails.Urgent).FirstOrDefault(p => p.MatchesReason(ContactReason.Website))?.Methods.FirstOrDefault();
}