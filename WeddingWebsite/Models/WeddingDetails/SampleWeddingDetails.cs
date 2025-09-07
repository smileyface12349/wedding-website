using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WeddingDetails;

/// <summary>
/// Used to test authorization - should not be accessible to unauthenticated users.
/// This data is still fake, and is safe to go on git.
/// </summary>

[Authorize]
public class SampleWeddingDetails : IWeddingDetails
{
    public SampleWeddingDetails() {
        // Cannot access venues in static context
        Events = new List<Event>
        {
            new ("Ceremony", TimeOnly.Parse("12:00"), TimeOnly.Parse("13:00"), "The church service in which we get married.", CeremonyVenue, new WebsiteImage("https://www.wedgewoodweddings.com/hubfs/3.0%20Feature%20Images%201000%20x%20500%20px/Blog/Lets%20Talk%20About%20Beach%20Weddings.png", "A wedding ceremony on a beach")),
            new ("Drinks Reception", TimeOnly.Parse("13:30"), TimeOnly.Parse("15:00"), "Join us for drinks and canapés in the garden.", ReceptionVenue, new WebsiteImage("https://www.confetti.co.uk/blog/wp-content/uploads/2013/04/alitrystan39.jpg", "Some bottles of champagne surrounded by lots of empty glasses")),
            new ("Wedding Breakfast", TimeOnly.Parse("15:30"), TimeOnly.Parse("18:00"), "A sit-down meal with speeches and toasts.", ReceptionVenue, new WebsiteImage("https://wpmedia.bridebook.com/wp-content/uploads/2024/12/tTqnnv01-858154ee-97ae-4e73-ab3c-ccc28bdeb395.jpg", "A long table with guests eating food"), null, [new WeddingModal("View Menu", [new ("Main Course", "Roast chicken, potatoes and vegetables")])]),
            new ("Evening Reception", TimeOnly.Parse("19:00"), TimeOnly.Parse("23:00"), "An evening of dancing and celebration.", ReceptionVenue, new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding"))
        };
        
        // Cannot access bride and groom in static context
        Contacts = new List<Contact> {
            new("John", "Smith", "Best Man", new ContactDetails("john.smith@gmail.com", "07123456780"), "Cancellations / attendance"),
            new("Jane", "Doe", "Maid of Honour", new ContactDetails("jane.doe@gmail.com", "07123456781"), "Issues with the website"),
            new("Jim", "Brown", "Photographer", new ContactDetails("jim.brown@gmail.com", null), "Photography enquiries"),
            new("Peter", "Johnson", "Venue Coordinator", new ContactDetails("peter.johnson@gmail.com", null), "Catering / dietary requirements"),
            new(Bride, "Bride", "All other enquiries"),
            new(Groom, "Groom", "All other enquiries"),
        };
    }

    public Fiance Groom { get; } 
        = new("Spongebob", "Squarepants", new ContactDetails("adam@garden.eden", "07123456789"));
        
    public Fiance Bride { get; }
        = new("Scooby", "Doo", new ContactDetails("eve@garden.eden", "07123456788"));
        
    public DateOnly WeddingDate { get; } = DateOnly.Parse("2028-8-14");
        
    public ReceptionVenue ReceptionVenue { get; } = new(
        "Garden of Eden", 
        new Location(12345, 67890), 
        "123 Paradise Lane, Eden, ED1 2AB",
        new TravelDirections(
            "<p>We suggest arriving by foot.</p><p><b>Parking: </b>There is no parking available, except for blue badge holders.</p>",
            20,
            new WebsiteImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDaBHvigmC_MQkDbMzRE4RXDeaqbJgwxTqIA&s", "A wedding car")
        )
    );
    
    public CeremonyVenue CeremonyVenue { get; } = new(
        "St Mary's Church", 
        new Location(12345, 67890), 
        "456 Holy Road, Eden, ED3 4GH",
        new TravelDirections(
            @"<p>We suggest arriving by car. If you do not have a car, please let us know when you RSVP and we can arrange a lift for you.</p>
                        <p><b>Parking: </b>Please follow the signs to car parking. Please do not park in the spaces directly outside the entrance unless you are a blue badge holder, or have been informed directly that you may park there.</p>",
            null,
            new WebsiteImage("https://www.instant-quote.co/images/cars/large/o_1ikkmciu01pgc1uko1lh71o60j0p1c.jpeg", "A wedding car")
        )
    );
    
    public IEnumerable<Event> Events { get; } 
    
    public DressCode DressCode { get; } 
        = new DressCode("Cocktail", "Please dress smartly for the occasion. Cocktail attire is preferred, but feel free to wear something that makes you feel comfortable and happy.");
    
    public AccommodationDetails AccommodationDetails { get; } = new (
        "If you would like to stay until the end, we suggest staying at a nearby hotel.",
        new List<Hotel> {
            new ("Eden Hotel",  new Location(1234, 5678), "789 Hotel Street, Eden, ED5 6JK", 18, 95, new Discount(15, "Quote 'Garden of Eden'")),
            new("Paradise Inn", new Location(1234, 5678), "101 Paradise Avenue, Eden, ED7 8LM", 12, 75, Discount.None())
        },
        new WebsiteImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2IlovA50T00WLRbsaxCZgu5i-YF1z7zI4Vg&s", "A hotel room")
    );
    
    public IEnumerable<Contact> Contacts { get; }
    
    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("https://images.squarespace-cdn.com/content/v1/60167718645a930edf99bede/6fb36556-54ab-4a9e-9224-be3ef81587e5/K%2BM+-+Pheasantry+Brewery+Wedding+27.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
    public IEnumerable<WebsiteImage> GalleryImages { get; } = new List<WebsiteImage>();
    
    public WebsiteLink RegistryLink { get; }
        = new WebsiteLink("https://youtu.be/dQw4w9WgXcQ");
        
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.ContactUs;
}