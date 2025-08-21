namespace WeddingWebsite.Models;

public enum UserPrivilege
{
    /// <summary>
    /// Full access to viewing and updating all users.
    /// </summary>
    Admin,
    
    /// <summary>
    /// Guest of reception and ceremony. Can view all information and RSPV.
    /// </summary>
    ReceptionGuest,
    
    /// <summary>
    /// Guest of ceremony only. Can view a limited amount of information, and not RSPV.
    /// You may want to have just one account for ceremony guests.
    /// </summary>
    CeremonyGuest,
    
    /// <summary>
    /// A logged-out user.
    /// </summary>
    None
}