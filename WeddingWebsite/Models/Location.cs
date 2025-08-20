namespace WeddingWebsite.Models;

/// <summary>
/// Latitude and longitude for use in automated things like maps.
/// </summary>
public record Location(
    long Latitude,
    long Longitude
);