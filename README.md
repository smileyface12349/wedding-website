# wedding-website

## (Planned) Features

- Customisable homepage with a variety of pre-built sections including location, timings of the day, accommodation and contact details.
- Simple but robust theming support to quickly hot-swap the colours within particular sections.
- A login system for guests to RSPV and view their table number. You may add multiple guests to a single account.
- Responsive interface for all screen sizes.
- Total separation of data and functionality makes it easy to customise the website for a different wedding, and keep private information off git.

## How it's built
This app uses Blazor, a full stack C# framework. This means both the frontend and backend are in C#.

A key decision for this app is to separate the web layout from the data. All components will be passed in an `IWeddingDetails` which they can use to get all the information specific to the wedding. This means all you need to do to customise it for your wedding is simply provide another implementation of this interface.

This repository does not contain a real implementation so that the details are kept private, but it does contain `SampleWeddingDetails` with various bits of sample data that are suitable for testing and demo purposes.

## Setup Instructions

1. Fork this repository.
2. Run `dotnet restore`.
3. Set up the database.
4. Do configuration (optional for now).
5. Install .NET 9, then run the website with `dotnet run Program.cs`. This will host your website locally. You may also want to set up a service to keep this running and/or a reverse proxy. Note you should use `dotnet publish` instead for production use.

## Configuration

Configuration is done in two entirely separate places.

### Wedding Details

This is for all details related to the wedding. I try and stay away from implementation details in this class, it merely specifies information about the wedding and it's up to each section to choose how to render it. 

By default, `SampleWeddingDetails.cs` is being used. If you go into `Program.cs`, you can change `SampleWeddingDetails.cs` to your new implementation of `IWeddingDetails`

### Website Config

The config affects how the website displays, but is completely separate from the details of the wedding. This includes which sections there are, colour scheme and other options for each section.

If you're making a new feature and you're feeling generous, hide it behind a config option and then PR it! This will allow other people to benefit from your contributions. I will try and review PRs quickly, although please note that I am unlikely to change the default behaviour in a way that is merely personal preference, I'll only change the default behaviour to fix bugs and make changes which are definitely improvements.

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

A license will be added once more of the code is completed. For now, you do not have permission to use, modify or distribute any of this code.

Please note that commercial use is prohibited, as this project makes use of assets which do not permit commercial use.
