using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.Accommodation;

public record Hotel (
    string Name,
    string Description,
    Location Location,
    string Address,
    int DrivingTimeFromVenueMinutes,
    Price ApproximatePrice,
    string Link,
    bool Emphasise = false,
    IWebsiteElement? Media = null
);