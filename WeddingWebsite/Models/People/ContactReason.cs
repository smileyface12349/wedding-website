using System.ComponentModel;

namespace WeddingWebsite.Models.People;

public enum ContactReason
{
    [Description("Attendance & RSPVs")]
    Attendance,
    
    [Description("Dietary Requirements & Special Arrangements")]
    DietaryRequirements,
    
    [Description("Accommodation")]
    Accommodation,
    
    [Description("Registry & Gifts")]
    Registry,
    
    [Description("Travel & Logistics")]
    Logistics,
    
    [Description("Website")]
    Website,
    
    [Description("Other Enquiries")]
    Other,
    
    [Description("I want to contact a specific person")]
    SpecificPerson
}