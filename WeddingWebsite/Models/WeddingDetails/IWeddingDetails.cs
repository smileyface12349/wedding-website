using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WeddingDetails;

public interface IWeddingDetails
{
    // Information about the Wedding
    public IEnumerable<IPerson> NotablePeople { get; }
    public DateOnly WeddingDate { get; }
    public ReceptionVenue ReceptionVenue { get; }
    public CeremonyVenue CeremonyVenue { get; }
    public IEnumerable<Event> Events { get; }
    public DressCode DressCode { get; }
    public AccommodationDetails AccommodationDetails { get; }
    public IEnumerable<IContact> Contacts { get; }
    
    // Static Files and External Links
    public WebsiteImage MainImage { get; }
    public IEnumerable<WebsiteImage> GalleryImages { get; }
    public WebsiteLink RegistryLink { get; }
    
    // Helper methods
    public IPerson Groom => NotablePeople.First(p => p.Role == Role.Groom);
    public IPerson Bride => NotablePeople.First(p => p.Role == Role.Bride);
}