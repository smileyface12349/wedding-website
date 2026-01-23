using WeddingWebsite.Models;
using WeddingWebsite.Models.Accommodation;
using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Events;
using WeddingWebsite.Models.Gallery;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.WeddingDetails;

/// <summary>
/// A barebones implementation, for you to use as a template for your own wedding. This is not suitable for use in its
/// current form!
/// </summary>

public sealed class WeddingDetailsTemplate : IWeddingDetails
{
    public WeddingDetailsTemplate() {
        
        // Define your events here, in order.
        Events = new List<Event>
        {
            new (
                "Ceremony", 
                TimeOnly.Parse("13:00"), 
                TimeOnly.Parse("14:30"), 
                "Description here.",
                CeremonyVenue,
                null,
                new WebsiteImage("/img/todo.jpg", null)
            ),
            new (
                "Wedding Breakfast", 
                TimeOnly.Parse("16:00"), 
                TimeOnly.Parse("19:00"),
                "Description here.", 
                ReceptionVenue, 
                null,
                new WebsiteImage("/img/todo.jpg", null)
            ),
        };
        
    }
    
    // You may wish to define your venue(s) here so that you can use them in multiple places.
    public Venue ReceptionVenue { get; } = new(
        "Reception Venue", 
        new Location(0, 0), 
        "Address goes here"
    );
    public Venue CeremonyVenue { get; } = new(
        "Ceremony Venue", 
        new Location(0, 0), 
        "Address goes here"
    );
    
    // Events has been done in the constructor so that the venue(s) can be used in them.
    public IEnumerable<Event> Events { get; } 

    // Must contain the bride and groom. Also include anyone else you want to be contactable or in the "meet the
    // wedding party" section (if you're having one).
    public IEnumerable<NotablePerson> NotablePeople { get; } = [
        new (
            new Name("Name", "Surname"),
            Role.Groom
        ),
        new (
            new Name("Name", "Surname"),
            Role.Bride
        )
    ];
    
    // The date of the wedding.
    public DateOnly WeddingDate { get; } = DateOnly.Parse("2028-8-14");
    
    // Show on the login page and at the top of the homepage
    public WebsiteImage MainImage { get; } 
        = new ("/img/todo.jpg", null);
    
    // Used in dress code section only.
    public DressCode DressCode { get; } 
        = new DressCode(
            "Dress Code", 
            []
        );
    
    // Used in "how we met" section only.
    public Backstory Backstory { get; } 
        = new Backstory(
            "Add a short paragraph describing how you met.",
            null,
            null
        );
    
    // Used in accommodation section or timeline.
    public AccommodationDetails AccommodationDetails { get; } = new (
        "",
        []
    );
    
    // Can be used to add shared inboxes or other contacts not tied to a person.
    public IEnumerable<IContact> ExtraContacts { get; } = [];
        
    // Used in the gallery section and the gallery page.
    public GalleryItems Gallery { get; } = new (
        [],
        []
    );
}