namespace WeddingWebsite.Models;

/// <summary>
/// Determines whether users are permitted to bring along additional guests that haven't been explicitly invited
/// </summary>
public enum UsersCanAddGuests
{
    /// <summary>
    /// Displays a message saying that bringing along a "plus one" is not allowed, unless they are invited already.
    /// </summary>
    No,
    
    /// <summary>
    /// Displays a message saying to contact the couple if you would like to bring a plus one, and they will consider it.
    /// </summary>
    ContactUs
    
    // Not implemented as I'm not using the functionality: OnePerUser, OnePerGuest, Unlimited
    
}