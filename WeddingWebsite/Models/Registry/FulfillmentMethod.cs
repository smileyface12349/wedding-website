using System.ComponentModel;

namespace WeddingWebsite.Models.Registry;

public enum FulfillmentMethod
{
    [Description("Bring it on the day")]
    BringOnDay,
    
    [Description("Deliver it to us in advance")]
    DeliverToUs,
    
    [Description("Transfer the money to us")]
    TransferMoney
}