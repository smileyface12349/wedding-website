namespace WeddingWebsite.Models.WeddingDetails;

/// <summary>
/// This information should look and feel like real information, but not be real information.
/// This is used to demo the website to users that are not logged in.
/// </summary>
public class SampleWeddingDetails : IWeddingDetails
{
    public SampleWeddingDetails() {
        // Cannot access venues in static context
        Events = new List<Event>
        {
            new ("Ceremony", TimeOnly.Parse("12:00"), TimeOnly.Parse("13:00"), "The church service in which we get married.", CeremonyVenue),
            new ("Drinks Reception", TimeOnly.Parse("13:30"), TimeOnly.Parse("15:00"), "Join us for drinks and canapés in the garden.", ReceptionVenue),
            new ("Wedding Breakfast", TimeOnly.Parse("15:30"), TimeOnly.Parse("18:00"), "A sit-down meal with speeches and toasts.", ReceptionVenue),
            new ("Evening Reception", TimeOnly.Parse("19:00"), TimeOnly.Parse("23:00"), "An evening of dancing and celebration.", ReceptionVenue)
        };
    }

    public Fiance Groom { get; } 
        = new("Adam", "Smith", new ContactDetails("adam@garden.eden", "07123456789"));
        
    public Fiance Bride { get; }
        = new("Eve", "Williams", new ContactDetails("eve@garden.eden", "07123456788"));
        
    public DateOnly WeddingDate { get; } = DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(1));
        
    public ReceptionVenue ReceptionVenue { get; } = new(
        "Garden of Eden", 
        new Location(12345, 67890), 
        "123 Paradise Lane, Eden, ED1 2AB",
        new TravelDirections(
            "We suggest arriving by foot.",
            "There is no parking available at the venue."
        )
    );
    
    public CeremonyVenue CeremonyVenue { get; } = new(
        "St Mary's Church", 
        new Location(12345, 67890), 
        "456 Holy Road, Eden, ED3 4GH",
        new TravelDirections(
            "We suggest arriving by car. If you do not have a car, please let us know when you RSVP and we can arrange a lift for you.",
            "Please follow the signs to car parking. Please do not park in the spaces directly outside the entrance unless you are a blue badge holder, or have been informed directly that you may park there."
        )
    );
    
    public IEnumerable<Event> Events { get; } 
    
    public DressCode DressCode { get; } 
        = new DressCode("Cocktail", "Please dress smartly for the occasion. Cocktail attire is preferred, but feel free to wear something that makes you feel comfortable and happy.");
    
    public AccommodationDetails AccommodationDetails { get; } = new AccommodationDetails(
        "Given the even will run late into the evening, we suggest staying at a nearby hotel.",
        new Hotel("Eden Hotel",  new Location(1234, 5678), "789 Hotel Street, Eden, ED5 6JK", 95, new Discount(15, "Quote 'GARDENWEDDING' for 15% off your stay.")),
        new List<Hotel> {
            new("Paradise Inn", new Location(1234, 5678), "101 Paradise Avenue, Eden, ED7 8LM", 75, new Discount.None())
        }
    );
    
    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("https://images.squarespace-cdn.com/content/v1/60167718645a930edf99bede/6fb36556-54ab-4a9e-9224-be3ef81587e5/K%2BM+-+Pheasantry+Brewery+Wedding+27.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
    public IEnumerable<WebsiteImage> GalleryImages { get; } = new List<WebsiteImage>();
    
    public WebsiteLink RegistryLink { get; }
        = new WebsiteLink("https://youtu.be/dQw4w9WgXcQ");
        
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.ContactUs;
}