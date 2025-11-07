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
            "It all began when SpongeBob SquarePants took a wrong turn at Jellyfish Fields and ended up in a spooky kelp forest — only to bump into Scooby-Doo chasing what he thought was a sea ghost (it was just a jellyfish wearing sunglasses). After a shared snack of Scooby Snacks and Krabby Patties, the two instantly bonded over their love of mysteries and mayonnaise. From that day on, they were inseparable — solving underwater whodunits and laughing through haunted shipwrecks. Their wedding (attended by Shaggy and Patrick as co-best men) is a celebration of friendship, snacks, and just a little bit of underwater mystery.",
            GetPersonByRole(Role.Bride).Media,
            GetPersonByRole(Role.Groom).Media
        );
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
            new WebsiteImage("https://upload.wikimedia.org/wikipedia/commons/7/7a/SpongeBob_SquarePants_character.png", null),
            "124 Conch Street, Bikini Bottom, Pacific Ocean"
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
            new WebsiteImage("https://static.wikitide.net/greatcharacterswiki/thumb/5/5c/Original_scooby_doo.png/300px-Original_scooby_doo.png", null),
            "32 Mystery Lane, Coolsville, USA"
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
    
    private NotablePerson GetPersonByRole(Role role) => NotablePeople.First(p => p.Role == role);

    public DateOnly WeddingDate { get; } = DateOnly.Parse("2028-8-14");
        
    public Venue ReceptionVenue { get; } = new(
        "Garden of Eden", 
        new Location(48.8584196, 2.2943747), 
        "123 Paradise Lane, Eden, ED1 2AB",
        new TravelDirections(
            [
                new WebsiteSection(null, "We suggest arriving by foot."),
                new WebsiteSection("Parking", "There is no parking available, except for blue badge holders.")
            ],
            null,
            20
        ),
        "A beautiful picturesque garden for a wonderful party with the animals!",
        new WebsiteImage("https://media.swncdn.com/via/9367-flickr-faunggs-photos.jpg", "The Garden of Eden filled with animals and Adam and Eve"),
        [
            new WeddingModal("View Map", "Map not yet available.")
        ]
    );
    
    public Venue CeremonyVenue { get; } = new(
        "St Mary's Church", 
        new Location(12345, 67890), 
        "456 Holy Road, Eden, ED3 4GH",
        new TravelDirections(
            [
                new WebsiteSection(null, "We suggest arriving by car. If you do not have a car, please let us know when you RSVP and we can arrange a lift for you."),
                new WebsiteSection("Parking", "Please follow the signs to car parking. Please do not park in the spaces directly outside the entrance unless you are a blue badge holder, or have been informed directly that you may park there.")
            ],
            null,
            null,
            new WebsiteImage("https://www.instant-quote.co/images/cars/large/o_1ikkmciu01pgc1uko1lh71o60j0p1c.jpeg", "A wedding car")
        ),
        "A very large church, also for all the animals, I guess.",
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
        "If you would like to stay until the end, we suggest staying at a nearby hotel.",
        new List<Hotel> {
            new ("Eden Hotel",  "A beautiful hotel in the city centre, where the bride and groom will be staying", new Location(1234, 5678), "789 Hotel Street, Eden, ED5 6JK", 18, 95, new Discount(15, "Quote 'Garden of Eden'"), "https://youtube.com/watch?v=dQw4w9WgXcQ", true, new WebsiteImage("https://cf.bstatic.com/xdata/images/hotel/max1024x768/40819418.jpg?k=5b61764f9e2fc3823d22a5260cf2e432f15014af29170e99f432f25a1776765a&o=&hp=1", "A luxury hotel by a beach")),
            new("Paradise Inn", "A cheaper option if you're on a budget", new Location(1234, 5678), "101 Paradise Avenue, Eden, ED7 8LM", 12, 75, Discount.None(), "https://youtube.com/watch?v=dQw4w9WgXcQ"),
        },
        new WebsiteImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2IlovA50T00WLRbsaxCZgu5i-YF1z7zI4Vg&s", "A hotel room")
    );
    
    public IEnumerable<IContact> ExtraContacts { get; } = [
        new SharedInboxContact("Shared Inbox", [Role.Bride, Role.Groom], new ContactDetails(
            new ContactOptions(null, [new EmailAddress("shared@wedding.com")])
        ))
    ];

    public Backstory Backstory { get; }

    public WebsiteImage MainImage { get; } 
        = new WebsiteImage("https://images.squarespace-cdn.com/content/v1/60167718645a930edf99bede/6fb36556-54ab-4a9e-9224-be3ef81587e5/K%2BM+-+Pheasantry+Brewery+Wedding+27.jpg", "An image of the bride and groom hugging surrounded by the wedding guests taking pictures.");
        
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
        
    public UsersCanAddGuests UsersCanAddGuests => UsersCanAddGuests.ContactUs;
}