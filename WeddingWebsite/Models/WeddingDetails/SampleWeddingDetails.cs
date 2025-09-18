using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WeddingDetails;

/// <summary>
/// This file provides a git-tracked up-to-date selection of data suitable for development.
/// 
/// This is useful for:
///  - Trying out the website without needing to enter all your own information first.
///  - Seeing an example as this can be helpful when constructing your own implementation.
///  - Sharing screenshots of layout without revealing anything about your wedding.
///  - A standardized test environment to diagnose problems.
///  - Updates automatically with new releases so you can test out new releases before filling in details.
///  - Will facilitate any future unit testing that may be added.
///
/// In practice, you won't actually be using this implementation but I'd recommend keeping it around in case you need it.
/// </summary>

[Authorize]
public class SampleWeddingDetails : IWeddingDetails
{
    public SampleWeddingDetails() {
        // Cannot access venues in static context
        Events = new List<Event>
        {
            new (
                "Ceremony", 
                TimeOnly.Parse("12:00"), 
                TimeOnly.Parse("13:00"), 
                "The church service in which we get married.",
                CeremonyVenue, 
                new WebsiteImage("https://www.wedgewoodweddings.com/hubfs/3.0%20Feature%20Images%201000%20x%20500%20px/Blog/Lets%20Talk%20About%20Beach%20Weddings.png", "A wedding ceremony on a beach")
            ),
            new (
                "Drinks Reception", 
                TimeOnly.Parse("13:30"),
                TimeOnly.Parse("15:00"), 
                "Join us for drinks and canapés in the garden.", 
                ReceptionVenue, 
                new WebsiteImage("https://www.confetti.co.uk/blog/wp-content/uploads/2013/04/alitrystan39.jpg", "Some bottles of champagne surrounded by lots of empty glasses")
                ),
            new (
                "Wedding Breakfast", 
                TimeOnly.Parse("15:30"), 
                TimeOnly.Parse("18:00"),
                "A sit-down meal with speeches and toasts.", 
                ReceptionVenue, 
                new WebsiteImage("https://wpmedia.bridebook.com/wp-content/uploads/2024/12/tTqnnv01-858154ee-97ae-4e73-ab3c-ccc28bdeb395.jpg", "A long table with guests eating food"), 
                null, 
                [
                    new WeddingModal("View Menu", [
                        new ("Main Course", "Roast chicken, potatoes and vegetables")
                    ])
                ]
            ),
            new (
                "Evening Reception", 
                TimeOnly.Parse("19:00"),
                TimeOnly.Parse("23:00"),
                "An evening of dancing and celebration.", 
                ReceptionVenue, 
                new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding")
            )
        };
    }

    public IEnumerable<NotablePerson> NotablePeople { get; } = [
        new (
            new Name("Spongebob", "Squarepants"),
            Role.Groom,
            new ContactDetails(
                new ContactOptions([ContactReason.Logistics, ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("spongebob@squarepants.com")]),
                new ContactOptions(null, [new PhoneNumber("+441234567890")])
            ),
            [
                new WebsiteSection(null, "Spongebob is a fun-loving sea sponge who lives in a pineapple under the sea. He works as a fry cook at the Krusty Krab and loves jellyfishing in his free time."),
                new WebsiteSection("Hobbies", "Jellyfishing, blowing bubbles, karate with Sandy, and going on adventures with Patrick."),
                new WebsiteSection("Fun Fact", "Spongebob has a pet snail named Gary who meows like a cat.")
            ],
            new WebsiteImage("https://upload.wikimedia.org/wikipedia/commons/7/7a/SpongeBob_SquarePants_character.png", null)
        ),
        new (
            new Name("Scooby", "Doo"),
            Role.Bride,
            new ContactDetails(
                new ContactOptions([ContactReason.DressCode, ContactReason.SpecificPerson], [new EmailAddress("scooby@doo.net")]),
                new ContactOptions(null, [new PhoneNumber("+51395833759")])
            ),
            [
                new WebsiteSection(null, "Scooby Doo is a lovable Great Dane who solves mysteries with his best friend Shaggy and the rest of the Mystery Inc. gang. He has a big appetite and a knack for getting into hilarious situations."),
                new WebsiteSection("Hobbies", "Eating Scooby Snacks, solving mysteries, and napping."),
                new WebsiteSection("Fun Fact", "Scooby-Doo's name comes from the Frank Sinatra song \"Strangers in the Night\"")
            ],
            new WebsiteImage("https://static.wikitide.net/greatcharacterswiki/thumb/5/5c/Original_scooby_doo.png/300px-Original_scooby_doo.png", null)
        ),
        new (
            new Name("John", "Smith"),
            Role.BestMan,
            new ContactDetails(
                new ContactOptions([ContactReason.Attendance, ContactReason.SpecificPerson], [new EmailAddress("john.smith@gmail.com"), new EmailAddress("john.alt@gmail.com")])
            ),
            [
                new WebsiteSection(null, "John is the groom's childhood best friend. They met in primary school and have been inseparable ever since. John is known for his quick wit and sense of humor."),
                new WebsiteSection("Hobbies", "Playing football, video games, and hiking."),
                new WebsiteSection("Fun Fact", "John once won a local stand-up comedy competition.")
            ],
            new WebsiteImage("https://static.vecteezy.com/system/resources/previews/041/642/170/non_2x/ai-generated-portrait-of-handsome-smiling-young-man-with-folded-arms-isolated-free-png.png", null)
        ),
        new (
            new Name("Sally", "Williams"),
            Role.MaidOfHonour,
            new ContactDetails(
                new ContactOptions([ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("jane.doe@gmail.com")])
            ),
            [
                new WebsiteSection(null, "Sally is the bride's sister and best friend. They share a love for fashion and shopping. Sally is always there to lend a helping hand and offer support."),
                new WebsiteSection("Hobbies", "Shopping, yoga, and baking."),
                new WebsiteSection("Fun Fact", "This stuff is being completely AI written!")
            ],
            new WebsiteImage("https://png.pngtree.com/png-vector/20240528/ourmid/pngtree-front-view-of-a-smiling-business-woman-png-image_12509704.png", null)
        ),
        new (
            new Name("Mike", "Davis"),
            Role.Groomsman,
            new ContactDetails(
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("mike.davis@gmail.com")])
            ),
            [
                new WebsiteSection(null, "Mike is the groom's cousin and a loyal friend. He has a great sense of adventure and loves trying new things. Mike is always up for a challenge."),
                new WebsiteSection("Hobbies", "Rock climbing, traveling, and photography."),
                new WebsiteSection("Fun Fact", "Mike has traveled to over 20 countries.")
            ],
            new WebsiteImage("https://png.pngtree.com/png-clipart/20230927/original/pngtree-man-in-shirt-smiles-and-gives-thumbs-up-to-show-approval-png-image_13146336.png", null)
        ),
        new (
            new Name("Emily", "Johnson"),
            Role.Bridesmaid,
            new ContactDetails(
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("emily.johnson@gmail.com")])
            ),
            [
                new WebsiteSection(null, "Emily is the bride's childhood friend. They met in primary school and have been inseparable ever since. Emily is known for her kindness and generosity."),
                new WebsiteSection("Hobbies", "Reading, painting, and gardening."),
                new WebsiteSection("Fun Fact", "Emily once participated in a flash mob dance performance.")
            ],
            new WebsiteImage("https://static.vecteezy.com/system/resources/thumbnails/050/817/792/small_2x/happy-smiling-business-woman-in-suit-with-hand-pointing-at-empty-space-standing-isolate-on-transparent-background-png.png", null)
        ),
        new (
            new Name("Jane", "Butters"),
            Role.Bridesmaid,
            new ContactDetails(
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("jane.butters@gmail.com")])
            ),
            [
                new WebsiteSection(null, "Jane is the bride's college roommate and a close friend. They bonded over their love for music and art. Jane is always up for a good time and loves to make people laugh."),
                new WebsiteSection("Hobbies", "Playing guitar, attending concerts, and hiking."),
                new WebsiteSection("Fun Fact", "Jane can play three different musical instruments.")
            ],
            new WebsiteImage("https://static.vecteezy.com/system/resources/previews/009/257/276/non_2x/portrait-of-beautiful-young-asian-woman-file-png.png", null)
        ),
        new (
            new Name("Bob", "Marley"),
            Role.Groomsman,
            new ContactDetails(
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("bob.marley@gmail.com")])
            ),
            [
                new WebsiteSection(null, "Bob is the groom's work colleague and a great friend. They met at a company event and hit it off immediately. Bob is known for his positive attitude and infectious laughter."),
                new WebsiteSection("Hobbies", "Playing basketball, cooking, and fishing."),
                new WebsiteSection("Fun Fact", "Bob once cooked a meal for a celebrity chef.")
            ],
            new WebsiteImage("https://americanmigrainefoundation.org/wp-content/uploads/2022/12/GettyImages-1345864068.png", null)
        ),
        new (
            new Name("Jim", "Brown"),
            Role.Photographer,
            new ContactDetails(
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("jim.brown@gmail.com")])
            )
        ),
        new (
            new Name("Peter", "Johnson"),
            Role.VenueCoordinator,
            new ContactDetails(
                new ContactOptions([ContactReason.DietaryRequirements], [new EmailAddress("peter.johnson@gmail.com")])
            )
        ),
    ];
    
    private IPerson GetPersonByRole(Role role) => NotablePeople.First(p => p.Role == role);

    public DateOnly WeddingDate { get; } = DateOnly.Parse("2028-8-14");
        
    public Venue ReceptionVenue { get; } = new(
        "Garden of Eden", 
        new Location(48.8584196, 2.2943747), 
        "123 Paradise Lane, Eden, ED1 2AB",
        new TravelDirections(
            "<p>We suggest arriving by foot.</p><p><b>Parking: </b>There is no parking available, except for blue badge holders.</p>",
            null,
            20
        )
    );
    
    public Venue CeremonyVenue { get; } = new(
        "St Mary's Church", 
        new Location(12345, 67890), 
        "456 Holy Road, Eden, ED3 4GH",
        new TravelDirections(
            @"<p>We suggest arriving by car. If you do not have a car, please let us know when you RSVP and we can arrange a lift for you.</p>
                        <p><b>Parking: </b>Please follow the signs to car parking. Please do not park in the spaces directly outside the entrance unless you are a blue badge holder, or have been informed directly that you may park there.</p>",
            null,
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
            new ("Eden Hotel",  "A beautiful hotel in the city centre, where the bride and groom will be staying", new Location(1234, 5678), "789 Hotel Street, Eden, ED5 6JK", 18, 95, new Discount(15, "Quote 'Garden of Eden'"), "https://youtube.com/watch?v=dQw4w9WgXcQ", true),
            new("Paradise Inn", "A cheaper option if you're on a budget", new Location(1234, 5678), "101 Paradise Avenue, Eden, ED7 8LM", 12, 75, Discount.None(), "https://youtube.com/watch?v=dQw4w9WgXcQ"),
        },
        new WebsiteImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2IlovA50T00WLRbsaxCZgu5i-YF1z7zI4Vg&s", "A hotel room")
    );
    
    public IEnumerable<IContact> ExtraContacts { get; } = [
        new SharedInboxContact("Shared Inbox", [Role.Bride, Role.Groom], new ContactDetails(
            new ContactOptions(null, [new EmailAddress("shared@wedding.com")])
        ))
    ];
    
    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("https://images.squarespace-cdn.com/content/v1/60167718645a930edf99bede/6fb36556-54ab-4a9e-9224-be3ef81587e5/K%2BM+-+Pheasantry+Brewery+Wedding+27.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
    public IEnumerable<WebsiteImage> GalleryImages { get; } = new List<WebsiteImage>();
    
    public WebsiteLink RegistryLink { get; }
        = new WebsiteLink("https://youtu.be/dQw4w9WgXcQ");
        
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.ContactUs;
}