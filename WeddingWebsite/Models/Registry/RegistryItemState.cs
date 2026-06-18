using System.ComponentModel;

namespace WeddingWebsite.Models.Registry;

/// <summary>
/// The registry item state is a property of the item and a user who is looking at it. For example, if a user is not
/// admin they will see 'Claimed' even if the status is actually 'Received'. If a user themselves claimed an item they
/// may see the 'Pending' status, but other people would merely see 'Claimed'.
/// </summary>
public enum RegistryItemState
{
    [Description("Available")]
    Available,
    
    [Description("Claimed")]
    Claimed,
    
    [Description("Pending")]
    Pending,
    
    [Description("Completed")]
    Completed,
    
    [Description("Received")]
    Received
}