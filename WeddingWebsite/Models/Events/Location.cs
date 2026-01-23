namespace WeddingWebsite.Models.Events;

/// <summary>
/// Latitude and longitude for use in automated things like maps.
/// </summary>
public record Location(
    double Latitude,
    double Longitude
)
{
    public string GetGoogleMapsLink() => $"https://www.google.com/maps/search/?api=1&query={Latitude},{Longitude}";
}