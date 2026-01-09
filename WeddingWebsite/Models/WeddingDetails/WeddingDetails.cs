using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Models.Gallery;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.Venues;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;
using WeddingWebsite.Models.Accommodation;

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

public sealed class WeddingDetails : IWeddingDetails
{
    public WeddingDetails() {
        // Cannot access venues in static context
        Events = new List<Event>
        {
            new (
                "Arrival", 
                TimeOnly.Parse("13:30"), 
                TimeOnly.Parse("14:00"), 
                "To be ready to start at 2. Scroll down for directions to the venue.",
                CeremonyVenue, 
                null,
                new WebsiteImage("/img/3.webp", "A wedding ceremony on a beach")
            ),
            new (
                "Ceremony", 
                TimeOnly.Parse("14:00"), 
                TimeOnly.Parse("15:30"), 
                "The church service in which we get married.",
                CeremonyVenue, 
                null,
                new WebsiteImage("/img/1.jpg", "A wedding ceremony on a beach")
            ),
            new (
                "Tapas and outdoors time", 
                TimeOnly.Parse("15:30"),
                TimeOnly.Parse("17:30"), 
                "Join us for tapas and drinks in the garden.", 
                CeremonyVenue, 
                "The Courtyard",
                new WebsiteImage("https://www.confetti.co.uk/blog/wp-content/uploads/2013/04/alitrystan39.jpg", "Some bottles of champagne surrounded by lots of empty glasses")
                ),
            new (
                "Barbeque!", 
                TimeOnly.Parse("17:30"), 
                TimeOnly.Parse("20:00"),
                "A sit-down meal with speeches and toasts.", 
                CeremonyVenue, 
                "The Hall",
                new WebsiteImage("https://wpmedia.bridebook.com/wp-content/uploads/2024/12/tTqnnv01-858154ee-97ae-4e73-ab3c-ccc28bdeb395.jpg", "A long table with guests eating food"), 
                null, 
                [
                    new WeddingModal("View Menu", [
                        new ("Sides", "Patatas bravas, dips and other things"),
                        new ("Main Course", "Burgers and skewers"),
                        new ("Dessert", "Cake!")
                    ])
                ]
            ),
            new (
                "First dance and Ceilidh", 
                TimeOnly.Parse("20:00"),
                TimeOnly.Parse("22:00"),
                "An evening of dancing and celebration.", 
                CeremonyVenue, 
                "The Chapel",
                new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding")
            ),
            new (
                "First dance and Ceilidh", 
                TimeOnly.Parse("22:00"),
                TimeOnly.Parse("00:00"),
                "An evening of dancing and celebration.", 
                CeremonyVenue, 
                "The Chapel",
                new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding")
            )
        };
        
        // Using same images as with people
        Backstory = new Backstory(
            "It all began at uni",
            GetPersonByRole(Role.Bride).Media,
            GetPersonByRole(Role.Groom).Media
        );
    }

    public IEnumerable<NotablePerson> NotablePeople { get; } = [
        new (
            new Name("Jacob", "Warner"),
            Role.Groom,
            new ContactDetails(
                new ContactOptions([ContactReason.Logistics, ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("jacobewarmer@gmail.com")]),
                new ContactOptions(null, [new PhoneNumber("+44 7306 889587")])
            ),
            [
                new WebsiteSection(null, "Jacob finished studying at Warwick, now serving the church for a year before discovering what the next stage in life is..."),
                new WebsiteSection("Hobbies", "Music, Stories and Walking."),
                new WebsiteSection("Fun Fact", "I like cheese.")
            ],
            new WebsiteImage("https://upload.wikimedia.org/wikipedia/commons/7/7a/SpongeBob_SquarePants_character.png", null),
            "124 Conch Street, Bikini Bottom, Pacific Ocean"
        ),
        new (
            new Name("Amelia", "Kinghorn"),
            Role.Bride,
            new ContactDetails(
                new ContactOptions([ContactReason.DressCode, ContactReason.SpecificPerson], [new EmailAddress("akinghorn1084@gmail.com")]),
                new ContactOptions(null, [new PhoneNumber("+44 7562 390759")])
            ),
            [
                new WebsiteSection(null, "Amelia is Amelia. She loves being herself. She's finished Maths at Warwick and is now working at Dennis Eagle as a Data Analyst mixed with something else."),
                new WebsiteSection("Hobbies", "Walking, puzzling and napping."),
                new WebsiteSection("Fun Fact", "IDK yet")
            ],
            new WebsiteImage("https://static.wikitide.net/greatcharacterswiki/thumb/5/5c/Original_scooby_doo.png/300px-Original_scooby_doo.png", null),
            "32 Mystery Lane, Coolsville, USA"
        ),
        //new (
        //    new Name("John", "Smith"),
        //    Role.BestMan,
        //    new ContactDetails(
        //        new ContactOptions([ContactReason.Attendance, ContactReason.SpecificPerson], [new EmailAddress("john.smith@gmail.com"), new EmailAddress("john.alt@gmail.com")])
        //    ),
        //    [
        //        new WebsiteSection(null, "John is the groom's childhood best friend. They met in primary school and have been inseparable ever since. John is known for his quick wit and sense of humor."),
        //        new WebsiteSection("Hobbies", "Playing football, video games, and hiking."),
        //        new WebsiteSection("Fun Fact", "John once won a local stand-up comedy competition.")
        //    ],
        //    new WebsiteImage("https://static.vecteezy.com/system/resources/previews/041/642/170/non_2x/ai-generated-portrait-of-handsome-smiling-young-man-with-folded-arms-isolated-free-png.png", null)
        //),
        new (
            new Name("Alice", "Humphriss"),
            Role.MaidOfHonour,
            new ContactDetails(
                new ContactOptions([ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("IDK")])
            ),
            [
                new WebsiteSection(null, "Sally is the bride's sister and best friend. They share a love for fashion and shopping. Sally is always there to lend a helping hand and offer support."),
                new WebsiteSection("Hobbies", "Shopping, yoga, and baking."),
                new WebsiteSection("Fun Fact", "This stuff is being completely AI written!")
            ],
            new WebsiteImage("https://png.pngtree.com/png-vector/20240528/ourmid/pngtree-front-view-of-a-smiling-business-woman-png-image_12509704.png", null)
        ),
        new (
            new Name("Matthew", "Taylor"),
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
            new Name("Alicia", "Warner"),
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
            new Name("Isabelle", "Kinghorn"),
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
            new Name("Nathan", "Solomon"),
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
        //new (
        //    new Name("Jim", "Brown"),
        //    Role.Photographer,
        //    new ContactDetails(
        //        new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("jim.brown@gmail.com")])
        //    )
        //),
        //new (
        //    new Name("Peter", "Johnson"),
        //    Role.VenueCoordinator,
        //    new ContactDetails(
        //        new ContactOptions([ContactReason.DietaryRequirements], [new EmailAddress("peter.johnson@gmail.com")])
        //    )
        //),
    ]; 
    
    private NotablePerson GetPersonByRole(Role role) => NotablePeople.First(p => p.Role == role);
    
    public DateOnly WeddingDate { get; } = DateOnly.Parse("2026-8-9");
    
    public Venue CeremonyVenue { get; } = new(
        "The Oval Chapel", 
        new Location(51.825624, -0.359506), 
        "8? Highfield Oval, Harpenden AL5 4BX",
        new TravelDirections(
            [
                new WebsiteSection(null, "We suggest arriving by car. If you do not have a car, please let us know when you RSVP and we can arrange a lift for you."),
                new WebsiteSection("Parking", "Please follow the signs to car parking. Please do not park in the spaces directly outside the entrance unless you are a blue badge holder, or have been informed directly that you may park there.")
            ],
            null,
            null,
            new WebsiteImage("https://www.instant-quote.co/images/cars/large/o_1ikkmciu01pgc1uko1lh71o60j0p1c.jpeg", "A wedding car"),
            new WebsiteImage("https://www.instant-quote.co/images/cars/large/o_1ikkmciu01pgc1uko1lh71o60j0p1c.jpeg", "A wedding car")
        ),
        "A chapel.",
        new WebsiteImage("https://upload.wikimedia.org/wikipedia/commons/a/a6/St_Mary%27s_Southampton.jpg", "St Mary's Church, Southampton"),
        [
            new WeddingModal("Fire Safety Information", "Don't burn the place down, please.")
        ]
    );
    

    public IEnumerable<Event> Events { get; }

    
    public DressCode DressCode { get; } 
        = new DressCode(
            "Cocktail", 
            [
                new WebsiteSection(null, "Please arrive dressed in smart, polished attire perfect for an evening celebration."),
                new WebsiteSection("Men", "A dark suit and tie or a smart blazer with dress pants are perfect for this occasion. Finish the look with polished shoes and a sleek watch."),
                new WebsiteSection("Women", "A knee-length or midi dress, or a stylish jumpsuit, paired with elegant heels or dressy flats. Accessorize with a clutch and statement jewelry to complete your look.")
            ],
            new WebsiteImage("https://onefabday.com/wp-content/uploads/2023/03/122-mark-donovan-photography.jpg", "An image of female wedding guests in a line.")
        );
    
    public AccommodationDetails AccommodationDetails { get; } = new (
        null,
        new List<Hotel> {
        },
        new WebsiteImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2IlovA50T00WLRbsaxCZgu5i-YF1z7zI4Vg&s", "A hotel room")
    );
    
    public IEnumerable<IContact> ExtraContacts { get; } = [
        new SharedInboxContact("Shared Inbox", [Role.Bride, Role.Groom], new ContactDetails(
            new ContactOptions(null, [new EmailAddress("jacobandamelia.warner@gmail.com")])
        ))
    ];

    public Backstory Backstory { get; }

    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("/img/2.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
    public GalleryItems Gallery { get; } = new (
        [
            new GallerySection(
                [
                    new GalleryItem("https://pm1.aminoapps.com/6549/18b7f2ae94d82dbe03c54e4e8de0f17211236d70_hq.jpg"),
                    new GalleryItem("https://i.ytimg.com/vi/GAyzLbpZeKE/maxresdefault.jpg"),
                    new GalleryItem("https://ih1.redbubble.net/image.5821996399.7493/fposter,small,wall_texture,square_product,600x600.jpg"),
                    new GalleryItem("https://pbs.twimg.com/media/EbN2CI3WAAcVxXD?format=jpg&name=large"),
                    new GalleryItem("https://pbs.twimg.com/media/GfagNwOWQAAFWlB?format=jpg&name=medium"),
                    new GalleryItem("https://i.ytimg.com/vi/9tcHOMOVfrk/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLDJ8fvK_Ob-YZ66NKdIqKydgxvhZQ"),
                ], 
                "General Pictures", 
                "Aren't they having such a happy life together..."
            )
        ],
        [
            new BigGalleryItem(new WebsiteImage("https://pbs.twimg.com/media/GfagNwOWQAAFWlB?format=jpg&name=medium", null), "Credit: AI"),
            new BigGalleryItem(new WebsiteImage("https://pbs.twimg.com/media/EbN2CI3WAAcVxXD?format=jpg&name=large", null), "", "Spongebob Scooby", "Who made this...")
        ]
    );
    
    public WebsiteLink RegistryLink { get; }
        = new WebsiteLink("https://youtu.be/dQw4w9WgXcQ");
        
    //public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.ContactUs;
}