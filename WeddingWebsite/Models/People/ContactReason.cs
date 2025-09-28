using System.ComponentModel;

namespace WeddingWebsite.Models.People;

public enum ContactReason
{
    [Description("Attendance & RSVPs")]
    Attendance,
    
    [Description("Dietary Requirements & Special Arrangements")]
    DietaryRequirements,
    
    [Description("Dress Code")]
    DressCode,
    
    [Description("Accommodation")]
    Accommodation,
    
    [Description("Registry & Gifts")]
    Registry,
    
    [Description("Travel & Logistics")]
    Logistics,
    
    /// <summary>
    /// The first contact method with this reason is visible to unauthenticated users.
    /// </summary>
    [Description("Website")]
    Website,
    
    [Description("Other Enquiries")]
    Other,
    
    [Description("I want to contact a specific person")]
    SpecificPerson
}