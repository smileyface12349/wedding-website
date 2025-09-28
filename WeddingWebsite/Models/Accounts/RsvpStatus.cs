using System.ComponentModel;

namespace WeddingWebsite.Models.Accounts;

public enum RsvpStatus
{
    [Description("Yes")]
    Yes,
    
    [Description("No")]
    No,
    
    [Description("Waiting")]
    NotResponded
}