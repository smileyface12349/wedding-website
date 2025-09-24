using WeddingWebsite.Models;

namespace WeddingWebsite.Data.Enums;

public static class RsvpStatusEnumConverter
{
    /// <summary>
    /// Extension method to convert an RsvpStatus to an integer to go in the database.
    /// </summary>
    public static int ToDatabaseInteger(this RsvpStatus rsvpStatus)
    {
        return rsvpStatus switch
        {
            RsvpStatus.NotResponded => 0,
            RsvpStatus.No => 1,
            RsvpStatus.Yes => 2,
            _ => throw new ArgumentOutOfRangeException(nameof(rsvpStatus), rsvpStatus, null)
        };
    }

    /// <summary>
    /// Convert an RsvpStatus to an integer to go in the database. There is also an extension method if you prefer.
    /// </summary>
    public static int RsvpStatusToDatabaseInteger(RsvpStatus rsvpStatus)
    {
        return rsvpStatus.ToDatabaseInteger();
    }

    /// <summary>
    /// Convert an int from the database to an RSVP status. There is no alternative extension method.
    /// </summary>
    public static RsvpStatus DatabaseIntegerToRsvpStatus(int rsvpStatus)
    {
        return rsvpStatus switch
        {
            0 => RsvpStatus.NotResponded,
            1 => RsvpStatus.No,
            2 => RsvpStatus.Yes,
            _ => throw new ArgumentOutOfRangeException(nameof(rsvpStatus), rsvpStatus, null)
        };
    }
}