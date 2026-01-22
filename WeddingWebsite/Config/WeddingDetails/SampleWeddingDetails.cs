using WeddingWebsite.Models;
using WeddingWebsite.Models.Accommodation;
using WeddingWebsite.Models.Events;
using WeddingWebsite.Models.Gallery;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Config.WeddingDetails;

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

public sealed class SampleWeddingDetails : IWeddingDetails
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
                null,
                new WebsiteImage("https://www.wedgewoodweddings.com/hubfs/3.0%20Feature%20Images%201000%20x%20500%20px/Blog/Lets%20Talk%20About%20Beach%20Weddings.png", "A wedding ceremony on a beach")
            ),
            new (
                "Drinks Reception", 
                TimeOnly.Parse("13:30"),
                TimeOnly.Parse("15:30"), 
                "Join us for drinks and canapés in the garden.", 
                ReceptionVenue, 
                "The Courtyard",
                new WebsiteImage("https://www.confetti.co.uk/blog/wp-content/uploads/2013/04/alitrystan39.jpg", "Some bottles of champagne surrounded by lots of empty glasses")
                ),
            new (
                "Wedding Breakfast", 
                TimeOnly.Parse("15:30"), 
                TimeOnly.Parse("19:00"),
                "A sit-down meal with speeches and toasts.", 
                ReceptionVenue, 
                "The Barn",
                new WebsiteImage("https://wpmedia.bridebook.com/wp-content/uploads/2024/12/tTqnnv01-858154ee-97ae-4e73-ab3c-ccc28bdeb395.jpg", "A long table with guests eating food"), 
                null, 
                [
                    new WeddingModal("View Menu", [
                        new ("Starter", "Avocado and prawns"),
                        new ("Main Course", "Roast chicken, potatoes and vegetables"),
                        new ("Dessert", "Trio of chocolate brownie, lemon posset and creme brulee")
                    ])
                ]
            ),
            new (
                "Evening Reception", 
                TimeOnly.Parse("19:00"),
                TimeOnly.Parse("23:00"),
                "An evening of dancing and celebration.", 
                ReceptionVenue, 
                "The Barn",
                new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding")
            )
        };
        
        // Using same images as with people
        Backstory = new Backstory(
            "Joe and Carol met at a mutual friend's birthday party in 2020. They instantly hit it off and spent the entire evening talking and laughing together. After exchanging numbers, they went on their first date a week later to a cozy little café in the city. From that moment on, they were inseparable. They bonded over their shared love of travel, adventure, and trying new foods. Over the next few years, they explored many new places together, creating unforgettable memories along the way. In 2026, Joe proposed to Carol during a romantic sunset hike, and she happily said yes. Now, they are excited to start this new chapter of their lives together as husband and wife.",
            new WebsiteImage("https://png.pngtree.com/png-clipart/20231116/original/pngtree-beautiful-woman-person-photo-png-image_13589124.png", "A woman standing up"),
            new WebsiteImage("https://portermetrics.com/wp-content/uploads/2022/05/serious-thoughtful-man-making-assumption-looking-right-and-thinking-1.png", "A man smiling and looking to the right.")
        );
    }

    public IEnumerable<NotablePerson> NotablePeople { get; } = [
        new (
            new Name("Joe", "Priestley"),
            Role.Groom,
            new ContactDetails(
                new ContactOptions([ContactReason.Logistics, ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("joe.priestley@example.com")]),
                new ContactOptions(null, [new PhoneNumber("+441234567890")])
            ),
            [
                new WebsiteSection(null, "Joe is the groom and a software developer. He loves hiking, photography, and spending time with his dog."),
                new WebsiteSection("Hobbies", "Hiking, photography, and playing guitar."),
                new WebsiteSection("Fun Fact", "Joe once hiked the entire Appalachian Trail.")
            ],
            new WebsiteImage("https://www.publicdomainpictures.net/pictures/200000/nahled/central-african-man.jpg", null),
            "190 Meadowdale Close, Middlesbrough, TS2 1TJ"
        ),
        new (
            new Name("Carol", "Fenwick"),
            Role.Bride,
            new ContactDetails(
                new ContactOptions([ContactReason.DressCode, ContactReason.SpecificPerson], [new EmailAddress("carol.fenwick@example.com")]),
                new ContactOptions(null, [new PhoneNumber("+51395833759")])
            ),
            [
                new WebsiteSection(null, "Carol is the bride and a graphic designer. When she's not busy in another country, she loves to bake all kinds of sweet treats."),
                new WebsiteSection("Hobbies", "Painting, traveling, and cooking."),
                new WebsiteSection("Fun Fact", "Carol has visited over 30 countries.")
            ],
            new WebsiteImage("https://spablack.com/wp-content/uploads/2022/05/meghan_030.png", null),
            "Flat 5, The Avenue, Leeds, LS8 2DL"
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
                new ContactOptions([ContactReason.SpecificPerson], [new EmailAddress("jim.brown@example.com")])
            )
        ),
        new (
            new Name("Peter", "Johnson"),
            Role.VenueCoordinator,
            new ContactDetails(
                new ContactOptions([ContactReason.DietaryRequirements], [new EmailAddress("peter.johnson@example.com")])
            )
        ),
    ];
    
    private NotablePerson GetPersonByRole(Role role) => NotablePeople.First(p => p.Role == role);

    public DateOnly WeddingDate { get; } = DateOnly.Parse("2028-8-14");
        
    public Venue ReceptionVenue { get; } = new(
        "Buckingham Palace", 
        new Location(51.501263, -0.142153), 
        "London, SW1A 1AA",
        new TravelDirections(
            [
                new WebsiteSection("Walk", "We suggest walking from the church."),
                new WebsiteSection("Accessible Parking", " If you are a blue badge holder, a parking space will be provided."),
                new WebsiteSection("Train", "Using the tube will make your journey slower."),
                new WebsiteSection("Taxi", "Taxis can be hailed on the street or booked in advance. Ubers can be arranged on a mobile device at the end of the service."),
            ],
            "A quick walk down the road",
            5,
            null,
            new WebsiteImage("https://www.cityam.com/wp-content/uploads/2022/05/Tube-Map-May-2022-Elizabeth-line-through-Zone-1-1.jpg?w=742", "A tube map focusing mainly on zone 1.")
        ),
        "A large townhouse built in 1703 with many grand rooms to host our different events.",
        new WebsiteImage("https://www.goldentours.com/travelblog/wp-content/uploads/2022/07/Blue-Drawing-Room-Buckingham-Palace-Royal-Collection-Trust-%C2%A9-Her-Majesty-Queen-Elizabeth-II-2022-1024x760.jpg", "The interior of Buckingham Palace"),
        [
            new WeddingModal("View Map", "Map not yet available.")
        ]
    );
    
    public Venue CeremonyVenue { get; } = new(
        "Westminster Abbey", 
        new Location(51.4994561, -0.1273097), 
        "London, SW1P 3PA",
        new TravelDirections(
            [
                new WebsiteSection("Train", "We suggest arriving by tube. The church is a 3 minute walk from Westminster tube station, which is served by the circle and district lines."),
                new WebsiteSection("Cycling", "There is no bicycle parking available at the church, so we do not suggest cycling to the wedding."),
                new WebsiteSection("Parking", "There is no parking available, except for blue badge holders. Please contact us on the RSVP form if you require a parking space.")
            ],
            "A short walk from Westminster tube station",
            null,
            new WebsiteImage("https://www.instant-quote.co/images/cars/large/o_1ikkmciu01pgc1uko1lh71o60j0p1c.jpeg", "A wedding car"),
            new WebsiteGoogleMapsEmbed(new Location(51.4994561, -0.1273097))
        ),
        "A very large church for a very large wedding! This is our favourite church as we love the incredible architecture and history of the building.",
        new WebsiteImage("https://lh3.googleusercontent.com/gps-cs-s/AG0ilSxLAn3Rt0dftdxXpgsfkveZh7bMzVzP9Zm10eqtXY7jc-R0pxVovGAiMwspp5ad_q_xBOk8QFNiZsIzSo3wSqTviUphKliT7ufPtmJtwXSDxeSsiEtK7qSCU_0Hup63S5mvnM8daA=s680-w680-h510", "Westminster Abbey from the outside"),
        [
            new WeddingModal("Fire Safety Information", "Smoking is not permitted inside the church. Green emergency exit signs will direct you to your nearest exit.")
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
        "If you would like to stay until the end, we suggest staying at a nearby hotel.",
        new List<Hotel> {
            new ("The Rubens at the Palace",  "A beautiful 5-star hotel just a few minutes from the palace", new Location(51.4982679, -0.1435535), "39 Buckingham Palace Road, London, SW1W 0PS", 1, new Price(209, new Discount(10, "Quote 'Palace'")), "https://youtube.com/watch?v=dQw4w9WgXcQ", true, new WebsiteImage("https://prod-media.redcarnationhotels.com/media/iozjaisp/the-rubens-at-the-palace-exterior.jpg?width=768&height=732&format=jpg&quality=80&rxy=0.5789473684210527,0.9093197762021246&v=1dc7a72df2f9450", "The rubens hotel")),
            new("The Z Hotel", "A cheaper option if you'd rather something less exciting", new Location(51.4957314, -0.1462508), "5 Lower Belgrave Street, London, SW1W 0NR", 4, new Price(63), "https://youtube.com/watch?v=dQw4w9WgXcQ"),
        },
        new WebsiteImage("https://dynamic-media-cdn.tripadvisor.com/media/photo-o/2b/fd/4e/53/caption.jpg?w=900&h=500&s=1", "A hotel room")
    );
    
    public IEnumerable<IContact> ExtraContacts { get; } = [
        new SharedInboxContact("Shared Inbox", [Role.Bride, Role.Groom], new ContactDetails(
            new ContactOptions(null, [new EmailAddress("shared@wedding.com")])
        ))
    ];

    public Backstory Backstory { get; }

    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5e575ffdabec06285101e4d6/4c3cb02b-f6b9-40e4-a9b4-6b6d0a49b99a/engagement-fashionable-leo-carrillo-beach-malibu.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
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
            new BigGalleryItem(new WebsiteImage("https://english-wedding.com/wp-content/uploads/2023/06/ClearlyWildPhotography-beachengagement02-scaled.jpg", null), "Credit: Clearly Wild Photography"),
            new BigGalleryItem(new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5e575ffdabec06285101e4d6/0bcac31c-5167-4528-8a82-c635449c28c8/engagement-cinematic-silhouette-sunset-leo-carrillo-beach.JPG", null), "", "Los Angeles", "December 2017")
        ]
    );
    
    public WebsiteLink RegistryLink { get; }
        = new WebsiteLink("https://youtu.be/dQw4w9WgXcQ");
}