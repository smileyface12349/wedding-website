using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Data.Enums;

public static class FulfillmentMethodEnumConverter
{
    /// <summary>
    /// Extension method to convert an RsvpStatus to an integer to go in the database.
    /// </summary>
    public static int ToDatabaseInteger(this FulfillmentMethod fulfillmentMethod)
    {
        return fulfillmentMethod switch
        {
            FulfillmentMethod.BringOnDay => 0,
            FulfillmentMethod.DeliverToUs => 1,
            FulfillmentMethod.TransferMoney => 2,
            _ => throw new ArgumentOutOfRangeException(nameof(fulfillmentMethod), fulfillmentMethod, null)
        };
    }

    /// <summary>
    /// Convert an RsvpStatus to an integer to go in the database. There is also an extension method if you prefer.
    /// </summary>
    public static int FulfillmentMethodToDatabaseInteger(FulfillmentMethod fulfillmentMethod)
    {
        return fulfillmentMethod.ToDatabaseInteger();
    }

    /// <summary>
    /// Convert an int from the database to an RSVP status. There is no alternative extension method.
    /// </summary>
    public static FulfillmentMethod DatabaseIntegerToFulfillmentMethod(int fulfillmentMethod)
    {
        return fulfillmentMethod switch
        {
            0 => FulfillmentMethod.BringOnDay,
            1 => FulfillmentMethod.DeliverToUs,
            2 => FulfillmentMethod.TransferMoney,
            _ => throw new ArgumentOutOfRangeException(nameof(fulfillmentMethod), fulfillmentMethod, null)
        };
    }
}