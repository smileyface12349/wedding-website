namespace WeddingWebsite.Models.Venues;

/// <summary>
/// A venue that stuff happens in.
/// </summary>
public interface IVenue
{
    public string Name { get; }

    /// <summary>
    /// Location for use in automated things like maps.
    /// </summary>
    public Location Location { get; }
    
    /// <summary>
    /// Address to display to the user.
    /// </summary>
    public string Address { get; }
    
    /// <summary>
    /// Instructions for getting to the venue.
    /// </summary>
    public TravelDirections? Directions { get; }
}