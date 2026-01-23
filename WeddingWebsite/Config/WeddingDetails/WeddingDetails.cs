using WeddingWebsite.Models;
using WeddingWebsite.Models.Accommodation;
using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Events;
using WeddingWebsite.Models.Gallery;
using WeddingWebsite.Models.People;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Config.WeddingDetails;


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
                "Travel to the Oval Chapel! Please aim to arrive at 1:30pm so that we can all be seated and start promptly at 2pm.",
                CeremonyVenue, 
                "The Chapel",
                new WebsiteImage("/img/3.webp", "A wedding ceremony on a beach")
            ),
            new (
                "Ceremony", 
                TimeOnly.Parse("14:00"), 
                TimeOnly.Parse("15:30"), 
                "Come and witness us officially getting married! As well as the marriage, the ceremony will also involve a time of worship, a short talk, and some prayer. At the end of the ceremony, we will gather outside for a group photo. 😄",
                CeremonyVenue, 
                null,
                new WebsiteImage("/img/9.jpg", "A wedding ceremony on a beach")
            ),
            new (
                "Tapas Time", 
                TimeOnly.Parse("15:30"),
                TimeOnly.Parse("17:30"), 
                "Enjoy some Spanish Tapas and drinks in the garden (weather permitting) as you play some garden games and get to know each other with wedding guest Bingo. Or if you fancy a bit of quiet time, you can enjoy a nice walk through the field and woods behind the Chapel.",
                CeremonyVenue, 
                null,
                new WebsiteImage("/img/10.jpg", "Some bottles of champagne surrounded by lots of empty glasses")
                ),
            new (
                "BBQ and Speeches", 
                TimeOnly.Parse("17:30"), 
                TimeOnly.Parse("20:00"),
                "We'll be having homemade burgers for dinner followed by a variety of puddings and a couple of speeches here and there. Please make us aware of any dietary requirements when you RSVP.", 
                CeremonyVenue, 
                "The Hall",
                new WebsiteImage("/img/11.jpg", "A long table with guests eating food"), 
                null, 
                [
                    new WeddingModal("View Menu", [
                        new ("Sides", "Patatas Bravas, Salads and Salsas"),
                        new ("Main Course", "Homemade Burgers and Skewers - Both Meat and Vegan options available"),
                        new ("Dessert", "Cake!")
                    ])
                ]
            ),
            new (
                "First Dance and Ceilidh", 
                TimeOnly.Parse("20:00"),
                TimeOnly.Parse("22:00"),
                "Join us as we end the night with a Ceilidh! It's loads of fun and easy enough that anyone can join in!", 
                CeremonyVenue, 
                "The Chapel",
                new WebsiteImage("/img/12.jpg", "Guests dancing at a wedding")
            ),
            /*new (
                "Informal Ending", 
                TimeOnly.Parse("22:00"),
                TimeOnly.Parse("23:59"),
                "There are no further planned activities for the day, but feel free to stay for however much longer you so desire (preferably not past 5am).", 
                CeremonyVenue, 
                "The Chapel",
                new WebsiteImage("https://images.squarespace-cdn.com/content/v1/5f5afb7d868b466f42d4b4fb/77e1c31d-3913-4202-bd13-e5ce142a1f7f/wedding-dance-floor-playlist-20.png", "Guests dancing at a wedding")
            )*/
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
            ]
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
            ]
        ),
        new (
            new Name("Alice", "Humphriss"),
            Role.MaidOfHonour,
            new ContactDetails(
                new ContactOptions([ContactReason.Website, ContactReason.SpecificPerson], [new EmailAddress("IDK")])
            )
        ),
        new (
            new Name("Matthew", "Taylor"),
            Role.Groomsman
        ),
        new (
            new Name("Alicia", "Warner"),
            Role.Bridesmaid
        ),
        new (
            new Name("Isabelle", "Kinghorn"),
            Role.Bridesmaid
        ),
        new (
            new Name("Nathan", "Solomon"),
            Role.Groomsman
        ),
    ]; 
    
    private NotablePerson GetPersonByRole(Role role) => NotablePeople.First(p => p.Role == role);
    
    public DateOnly WeddingDate { get; } = DateOnly.Parse("2026-8-9");
    
    public Venue CeremonyVenue { get; } = new(
        "Highfield Oval", 
        new Location(51.82660574703517, -0.3598443120147474),
        "The Chapel, Highfield Oval, Harpenden AL5 4BX",
        new TravelDirections(
            [
                new WebsiteSection(null, "The venue is a 10 minute drive from the M1 (J10), or it is a 20 minute walk from Harpenden train station. When arriving, use the code 2810 to open the gate. The site is closed to the public on Sunday afternoons, but please be aware of the residents who live there."),
                new WebsiteSection("Parking", "Please use the map to see where you can park. Please do not drive on the Oval itself."),
                new WebsiteSection("Want to know more about the chapel?", "https://www.harpenden-history.org.uk/harpenden-history/buildings/other-harpenden-buildings/the_oval_harpenden"),
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
            "Something Blue!", 
            [
                new WebsiteSection(null, "It would be very special to us -ok, Amelia- if you would wear an outfit with a little something (or EVERYTHING) blue :D"),
                new WebsiteSection(null, "(Don't worry if you can't, just where whatever you want to celebrate with us!)"),
            ],
            new WebsiteImage("/img/8.png", "Blue!")
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
}