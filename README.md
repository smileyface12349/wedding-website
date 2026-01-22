# Wedding Website

## Features

- Customisable homepage with a variety of pre-built sections including location, timings of the day, accommodation and contact details.
- Simple but robust theming support to quickly hot-swap the colours within particular sections.
- A login system for guests to access the website, and a robust admin site to manage accounts. You may add multiple guests to a single account.
- (RSVP system is coming soon).
- Custom registry system allowing guests to browse items and claim them.
- Responsive interface for all screen sizes.
- Total separation of data and functionality makes it easy to customise the website for a different wedding, and keep private information off git.

## Setup Instructions

1. Fork this repository.
2. Install .NET 9 SDK.
3. Run `dotnet restore`.
4. Install dotnet ef, then run `dotnet ef database update` to set up the database.
5. Run the website with `dotnet run Program.cs` (in `/WeddingWebsite`). This will host your website locally.
6. Navigate to `/account/setup` and make your owner account.

Once you've done these essential steps in this order, you can do some other steps:
- Customise the website (see below).
- Use `dotnet publish` and get it working on your hosting provider. You'll want to set up a service to keep it running and use a reverse proxy like Nginx.

## Need Some Help?

**Tech Support**: If you run into trouble getting it set up or customising it, please raise a GitHub issue and I'll get back to you. If you don't have much coding experience or need more help, I'm happy to set up a call and guide you through the process. I'll be happy to offer up to 3 hours for free which should be enough to do your first-time setup and get everything up and running.

**Hosting**: I am happy to offer hosting on my own infrastructure for a fee. However, if you are able to get it set up on your own infrastructure then I strongly recommend opting for that option instead as if I am hosting it you will have to wait for me to review and deploy any changes to your source code.

**Further Development**: If there's something you want added, pitch it to me in an issue and I'll see what I think. Depending on how much I think it will benefit others I may make it for free or I may charge an hourly rate.

## Sections on the Homepage

The content shown on the demo screenshots is made up, and not based on a real wedding. The colours and backgrounds are all very easily customisable.

Sections can be added to the website in any order, using as many or as few sections as you like.

You can view this on the [demo site](https://wedding.joshhumphriss.com) or by expanding the section below.

<details>
<summary>View Images and Descriptions</summary>

### Top Section
<img width="1913" height="908" alt="image" src="https://github.com/user-attachments/assets/4a0faefa-71f2-40fc-8998-c099ee92c5ad" />

Displays a large background image and a countdown timer, with some customisable call-to-action buttons for key things that need doing currently (e.g. booking accommodation or RSVPing).
This section is required at the top, unlike the rest which you may add in any order.

### How We Met
<img width="1164" height="493" alt="image" src="https://github.com/user-attachments/assets/d345f5f6-5b21-4c4b-9f17-2b7f67ddb6a1" />

A simple paragraph to give a bit of backstory.

### Timeline
<img width="1065" height="840" alt="image" src="https://github.com/user-attachments/assets/cf98cd8b-5574-4cee-a01d-8feb78c25890" />

This unique timeline design conveys:
- Timings of the day (with options for pop-ups including extra details about each event).
- Travel directions (auto-generated for venue changes).
- Accommodation details (auto-generated at the end of the timeline).
All in one coherent view. I find this much easier to use than having separate sections for timings, travel directions and accommodation details.

### Simple Timeline
<img width="534" height="396" alt="image" src="https://github.com/user-attachments/assets/3868d870-cec3-47ec-92f1-58392f552073" />

If you'd rather just have a list of events and start times.

### Venue Showcase
<img width="1078" height="710" alt="image" src="https://github.com/user-attachments/assets/a7e92d91-d8ad-4157-b1cb-b37e142fa8b8" />

Shows you a little more information about the venues. Totally optional, as the important information is already in the timeline.

### Travel Directions
<img width="1063" height="743" alt="image" src="https://github.com/user-attachments/assets/bf5fbd22-0d48-4f27-954c-58dc1c719921" />

The directions are already shown in other places, but you can emphasise them here too.

### Accommodation
<img width="1076" height="743" alt="image" src="https://github.com/user-attachments/assets/8ca68e94-d464-4b7b-871f-46831cc5f61c" />

Gives a bit more space for the accommodation options. Totally optional, as this information is in the timeline already (but potentially less obvious).

### Meet the Wedding Party
<img width="1054" height="752" alt="image" src="https://github.com/user-attachments/assets/d191851f-6bd7-4a8d-87dc-fc15a7cf90f1" />

For a little more information about the important people. Comes with various display modes, including chat messages if you prefer that.

### Gallery
<img width="1051" height="749" alt="image" src="https://github.com/user-attachments/assets/76be2494-02b1-4fb5-953e-6284517b5504" />

There's a whole gallery page, but you can also choose a few to display on the homepage.

### Dress Code
<img width="1084" height="365" alt="image" src="https://github.com/user-attachments/assets/495fbe87-2494-4965-98f1-8a6f7ce1defa" />

A tiny section to display the dress code. Doesn't have to be wrapped in a box.

### Contacts
<img width="662" height="549" alt="image" src="https://github.com/user-attachments/assets/7b2bcfb9-c2d0-498c-bb1e-b40f3cc8540c" />

This section recommends particular people based on the type of enquiry and how urgent it is.

</details>

## The Registry

The registry feature allows you to make a list of items you want, each having as many different purchase methods as you want (including transferring the money to you). Users can then claim these items and choose how they want to purchase them. This gives you no restrictions on which items you can have, although you won't get any benefits of a normal registry like free delivery.

<img width="1043" height="840" alt="image" src="https://github.com/user-attachments/assets/472816ed-9a53-40f7-8ec0-d2ee9e955c43" />

## To-Do List

While you can use another service, it's easier to stay on the website. The to-do list allows you to co-ordinate tasks and keep track of what needs doing in one place. You can even assign guests to non-admin users, and tasks assigned to you will automatically appear on the homepage.

<img width="768" height="691" alt="image" src="https://github.com/user-attachments/assets/9f5a8a6c-bcc5-455e-bdbd-88445a7c3790" />

## Theming

There are some overall colours, however most of the theming is per-section. You will pass in a `SectionTheme` to each section, containing:
1. The background colour or image.
2. The primary colour to use for buttons etc. on this background.
3. What any boxes should look like. Sections do not use a particular style of box, instead you can choose between rounded and outlined boxes within the theme directly.

## Configuration

Configuration is done in two entirely separate places.

### Wedding Details

This is for all details related to the wedding. I try and stay away from implementation details in this class, it merely specifies information about the wedding and it's up to each section to choose how to render it. 

By default, `SampleWeddingDetails.cs` is being used. If you go into `Program.cs`, you can change `SampleWeddingDetails.cs` to your new implementation of `IWeddingDetails`

### Website Config

The config affects how the website displays, but is completely separate from the details of the wedding. This includes which sections there are, colour scheme and other options for each section.

To change the config, make a new class e.g. `CustomWebsiteConfig` that inherits from `DefaultConfig` and implements the `IWebsiteConfig` interface directly. To change section theming, you will probably want to override the whole Sections attribute (but you can modify only particular sections in your implementation).

If you're making a new feature and you're feeling generous, hide it behind a config option and then PR it! This will allow other people to benefit from your contributions. I will try and review PRs quickly, although please note that I am unlikely to change the default behaviour in a way that is merely personal preference. If you're thinking of making a PR, get in touch early on about your design approaches and I can give you early feedback!

## Interactivity

Interactivity is disabled by default, so if you're adding any new pages it will be rendered on the server only and none of the buttons will work. To use interactivity, choose one of the following three render modes.

While you may interchange render modes on the same page, I'd recommend setting the render mode for each page and having all components on the page use the same render mode. Otherwise, you will often end up with the worst of both worlds.

### Server-Side Rendering

Code in C#, with everything rendered on the server. Every button press triggers an HTTP request to re-render the component server-side.

- Advantages: Fast page load, Secure, Code maintainability, Blazor libraries, Easy to enable.
- Disadvantages: Slow interactivity, Connection required, Can be unstable.
- Best for: Usages where a stable internet connection is likely and buttons either trigger privileged requests that would need to go to the server anyway, or are non-essential (e.g. admin page, homepage).
- How to enable: Write `@rendermode InteractiveServer` at the top of the file.

### WebAssembly

Code in C#, rendering on the client. It is automatically pre-rendered on the server first.

- Advantages: Fast (except for first load), Code maintainability, Blazor libraries.
- Disadvantages: Nontrivial first page load time. Okay-ish support for older browsers.
- Best for: Complex client-side logic in specific pages that require lots of interactivity (e.g. RSPV form, registry).
- How to enable: Move the component to `WeddingWebsite.Client` project, then write `@rendermode InteractiveWebAssembly` at the top of the file.

### JavaScript

Code in JavaScript directly.

- Advantages: Fast, Reliable.
- Disadvantages: Very poor code maintainability. No server-side pre-rendering.
- Best for: The odd dropdown or simple component in an otherwise static page (e.g. homepage, gallery), when it feels silly to load WebAssembly for something that can be achieved with a few lines of JavaScript.
- How to enable: Create a scoped `.js` file with exported functions `onLoad`, `onUpdate` and `onDispose`. See `CountdownToDate` for an example. 

## License

Feel free to use this for your own wedding website, that's what it's here for! You're also entirely welcome to cut bits out of it and use it in your own project without any attribution (although some attribution would be lovely). You may remove the footer at the bottom of the website if you want. Please note I have no legal obligations to provide support or ensure this product works, although I will do my best.

However, if you are planning on setting up a wedding website maker business, I've added some additional restrictions. Most notably, before reaching the payment screen, customers must be explicitly prompted about the presence of this repository and how they can set up their website for free instead. Please see the license for more information.

Please be very careful that some of the assets used in this project have special license restrictions. For example:

The following assets are used in the project and do **not** permit commercial use. If you want to use this code in a commercial setting, you **must** remove these assets, or purchase a license yourself:
- [Amsterdam font](https://www.dafont.com/amsterdam.font)

The following assets are AI generated. If this is a problem, please do not use these assets:
- Bricks background `/bg/bricks.jpg`
- Blue flowers background `/bg/blue-flowers.png`

This list is not exhaustive, and it is your responsibility to check all assets (except source code).
