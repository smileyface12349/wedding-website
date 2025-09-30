# Wedding Website

## Features

- Customisable homepage with a variety of pre-built sections including location, timings of the day, accommodation and contact details.
- Simple but robust theming support to quickly hot-swap the colours within particular sections.
- A login system for guests to access the website, and a robust admin site to manage accounts. You may add multiple guests to a single account.
- (RSVP system is coming soon).
- Responsive interface for all screen sizes.
- Total separation of data and functionality makes it easy to customise the website for a different wedding, and keep private information off git.

## Theming

There are some overall colours, however most of the theming is per-section. You will pass in a `SectionTheme` to each section, containing:
1. The background colour or image.
2. The primary colour to use for buttons etc. on this background.
3. What any boxes should look like. Sections do not use a particular style of box, instead you can choose between rounded and outlined boxes within the theme directly.

## Sections

The content shown on the demo screenshots is made up, and not based on a real wedding. The colours and backgrounds are all very easily customisable.

Sections can be added to the website in any order, using as many or as few sections as you like.

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

### Venue Showcase
<img width="1078" height="710" alt="image" src="https://github.com/user-attachments/assets/a7e92d91-d8ad-4157-b1cb-b37e142fa8b8" />

Shows you a little more information about the venues. Totally optional, as the important information is already in the timeline.

### Meet the Wedding Party
<img width="1054" height="752" alt="image" src="https://github.com/user-attachments/assets/d191851f-6bd7-4a8d-87dc-fc15a7cf90f1" />

For a little more information about the important people. Comes with various display modes, including chat messages if you prefer that.

### Dress Code
<img width="1084" height="365" alt="image" src="https://github.com/user-attachments/assets/495fbe87-2494-4965-98f1-8a6f7ce1defa" />

A tiny section to display the dress code. Doesn't have to be wrapped in a box.

### Contacts
<img width="662" height="549" alt="image" src="https://github.com/user-attachments/assets/7b2bcfb9-c2d0-498c-bb1e-b40f3cc8540c" />

This section recommends particular people based on the type of enquiry and how urgent it is.


## Setup Instructions

1. Fork this repository.
2. Run `dotnet restore`.
3. Set up the database (might be `dotnet ef database update`, but that might not create it, TBD).
4. Install .NET 9 SDK.
5. Run the website with `dotnet run Program.cs`. This will host your website locally.

Once you've done these essential steps in this order, you can do some other steps:
- Customise the website (see below).
- Use `dotnet publish` and get it working on your hosting provider. You'll want to set up a service to keep it running and use a reverse proxy.

## Configuration

Configuration is done in two entirely separate places.

### Wedding Details

This is for all details related to the wedding. I try and stay away from implementation details in this class, it merely specifies information about the wedding and it's up to each section to choose how to render it. 

By default, `SampleWeddingDetails.cs` is being used. If you go into `Program.cs`, you can change `SampleWeddingDetails.cs` to your new implementation of `IWeddingDetails`

### Website Config

The config affects how the website displays, but is completely separate from the details of the wedding. This includes which sections there are, colour scheme and other options for each section.

To change the config, make a new class e.g. `CustomWebsiteConfig` that inherits from `DefaultConfig` and implements the `IWebsiteConfig` interface directly. To change section theming, you will need to override the whole Sections attribute.

If you're making a new feature and you're feeling generous, hide it behind a config option and then PR it! This will allow other people to benefit from your contributions. I will try and review PRs quickly, although please note that I am unlikely to change the default behaviour in a way that is merely personal preference.

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

Please note that commercial use is prohibited, as this project makes use of assets which do not permit commercial use. All assets (except for the sample page) are available for use, modification and distribution in non-commercial scenarios.
