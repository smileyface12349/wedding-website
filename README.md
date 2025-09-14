# wedding-website

## (Planned) Features

- Display static information about the wedding, including location, timings of the day, accommodation and contact details.
- A login system for guests to RSPV and view their table number. You may add multiple guests to a single account.
- Responsive interface for all screen sizes.
- Total separation of data and functionality makes it easy to customise the website for a different wedding, and keep private information off git.

## How it's built
This app uses Blazor, a full stack C# framework. This means both the frontend and backend are in C#.

A key decision for this app is to separate the web layout from the data. All components will be passed in an `IWeddingDetails` which they can use to get all the information specific to the wedding. This means all you need to do to customise it for your wedding is simply provide another implementation of this interface.

This repository does not contain a real implementation so that the details are kept private, but it does contain `SampleWeddingDetails` with various bits of sample data that are suitable for testing and demo purposes.

## Setup Instructions

1. Fork this repository
2. Navigate to `/Models/WeddingDetails` and supply a new implementation of `IWeddingDetails`. You may want to use `SampleWeddingDetails` as an example, and you may also safely remove `SampleWeddingDetails` if you don't need it. Then replace `SampleWeddingDetails` in `Program.cs` with your new implementation.
3. Set up the database (TODO).
4. Install .NET 9, then run the website with `dotnet run Program.cs`. This will host your website locally. You may also want to set up a service to keep this running and/or a reverse proxy. Note you should use `dotnet publish` instead for production use.

## Customising the Layout
Customising all the details is already possible, but what if you want to change the layout of the website? First, check if there's any configuration options in `IWeddingDetails` that suit your needs. If not, you'll need to make some changes to the code. You should be able to do this easily in your local repository. If you're feeling generous, hide your changes behind a configuration option in `IWeddingDetails` and then make a PR here with your changes so that other people can benefit from it! I will try and review PRs quickly and improve the product for everyone, however I will not merge any PRs that change the default behaviour in a way that is just 'personal preference'.

## License

A license will be added once more of the code is completed. For now, you do not have permission to use, modify or distribute any of this code.

Please note that commercial use is prohibited, as this project makes use of assets which do not permit commercial use.
