using System.ComponentModel;

namespace WeddingWebsite.Models.People;

/// <summary>
/// A big enum representing the primary role of anyone involved with the wedding. This is super safe to add more stuff
/// to, even if it overlaps in purpose with something else etc.
/// </summary>
public enum Role
{
    [Description("Bride")]
    Bride,
    
    [Description("Groom")]
    Groom,
    
    [Description("Maid of Honour")]
    MaidOfHonour,
    
    [Description("Bridesmaid")]
    Bridesmaid,
    
    [Description("Best Man")]
    BestMan,
    
    [Description("Groomsman")]
    Groomsman,
    
    [Description("Father of the Bride")]
    FatherOfBride,
    
    [Description("Mother of the Bride")]
    MotherOfBride,
    
    [Description("Father of the Groom")]
    FatherOfGroom,
    
    [Description("Mother of the Groom")]
    MotherOfGroom,
    
    [Description("Photographer")]
    Photographer,
    
    [Description("Videographer")]
    Videographer,
    
    [Description("Officiant")]
    Officiant,
    
    [Description("Vicar")]
    Vicar,
    
    [Description("Venue Coordinator")]
    VenueCoordinator,
    
    [Description("Guest")]
    NormalGuest,
    
    [Description("")]
    Unknown
}