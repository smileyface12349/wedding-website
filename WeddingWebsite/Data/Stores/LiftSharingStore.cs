using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using WeddingWebsite.Models.LiftSharing;
using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Data.Stores;

public class LiftSharingStore : ILiftSharingStore
{
    private const string ConnectionString = "DataSource=Data\\app.db;Cache=Shared";

    public void AddLift(ISharedLift lift)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = """
            INSERT INTO SharedLifts (Id, UserId, Name, Spaces, StartLocation, StartTime, EndLocation, EndTime, Notes)
            VALUES (:id, :userId, :name, :spaces, :startLocation, :startTime, :endLocation, :endTime, :notes)
        """;
        
        cmd.Parameters.AddWithValue(":id", lift.Id);
        cmd.Parameters.AddWithValue(":userId", lift.UserId);
        cmd.Parameters.AddWithValue(":name", lift.Name);
        cmd.Parameters.AddWithValue(":spaces", lift.Spaces);
        cmd.Parameters.AddWithValue(":startLocation", lift.Start.Location);
        cmd.Parameters.AddWithValue(":startTime", lift.Start.Time.Ticks);
        cmd.Parameters.AddWithValue(":endLocation", lift.End.Location);
        cmd.Parameters.AddWithValue(":endTime", lift.End.Time.Ticks);
        cmd.Parameters.AddWithValue(":notes", lift.Notes);
        cmd.ExecuteNonQuery();
    }
    
    public void RenameLift(string id, string newName)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE SharedLifts SET Name = :name WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":name", newName);
        cmd.ExecuteNonQuery();
    }

    private int GetNumSpaces(string liftId, SqliteConnection connection, SqliteTransaction transaction)
    {
        // Determine total number of spaces
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT Spaces FROM SharedLifts WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", liftId);
        var result = cmd.ExecuteScalar();
        if (result == null)
        {
            return 0;
        }
        var totalSpaces = Convert.ToInt32(result);
        
        // Determine number of bookings
        var numBookings = GetNumBookings(liftId, connection, transaction);
        
        // Output difference
        return totalSpaces - numBookings;
    }

    private int GetNumBookings(string liftId, SqliteConnection connection, SqliteTransaction transaction)
    {
        // Determine number of bookings by guests
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT COUNT(*) FROM SharedLiftGuestBookings WHERE LiftId = :id";
        cmd.Parameters.AddWithValue(":id", liftId);
        var guestBookingCount = Convert.ToInt32(cmd.ExecuteScalar());

        // Determine number of bookings by non-guests
        cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "SELECT COUNT(*) FROM SharedLiftNonGuestBookings WHERE LiftId = :id";
        cmd.Parameters.AddWithValue(":id", liftId);
        var nonGuestBookingCount = Convert.ToInt32(cmd.ExecuteScalar());

        // Output sum
        return guestBookingCount + nonGuestBookingCount;
    }
    
    public bool ChangeSpaces(string id, int newSpaces)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var totalBookings = GetNumBookings(id, connection, transaction);
        if (newSpaces < totalBookings)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "UPDATE SharedLifts SET Spaces = :spaces WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":spaces", newSpaces);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }

    public bool DeleteLift(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var totalBookings = GetNumBookings(id, connection, transaction);
        if (totalBookings > 0)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "DELETE FROM SharedLifts WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }

    public SharedLiftWithBookings? GetLift(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = """
                          SELECT SharedLifts.Id, UserId, Name, Spaces, StartLocation, StartTime, EndLocation, EndTime, Notes, AspNetUsers.Email
                          FROM SharedLifts 
                          INNER JOIN AspNetUsers ON SharedLifts.UserId = AspNetUsers.Id
                          WHERE SharedLifts.Id = :id
                          """;
        cmd.Parameters.AddWithValue(":id", id);
        using var reader = cmd.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }
        
        var liftId = reader.GetString(0);
        var userId = reader.GetString(1);
        var name = reader.GetString(2);
        var spaces = reader.GetInt32(3);
        var startLocation = reader.GetString(4);
        var startTime = new DateTime(reader.GetInt64(5), DateTimeKind.Utc);
        var endLocation = reader.GetString(6);
        var endTime = new DateTime(reader.GetInt64(7), DateTimeKind.Utc);
        var notes = reader.GetString(8);
        var userEmail = reader.GetString(9);
        
        var bookings = GetBookings(liftId, connection);
        
        return new SharedLiftWithBookings(liftId, userId, userEmail, name, spaces, new JourneyEndpoint(startLocation, startTime), new JourneyEndpoint(endLocation, endTime), bookings, notes);
    }

    private IList<SharedLiftBooking> GetBookings(string liftId, SqliteConnection connection)
    {
        var bookings = new List<SharedLiftBooking>();

        // Get guest bookings
        var cmd = connection.CreateCommand();
        cmd.CommandText = """
                          SELECT Guests.UserId, Guests.GuestId, BookedAt, AcknowledgedAt, Guests.FirstName, Guests.LastName, AspNetUsers.Email
                          FROM SharedLiftGuestBookings
                          INNER JOIN Guests ON SharedLiftGuestBookings.GuestId = Guests.GuestId
                          INNER JOIN AspNetUsers ON Guests.UserId = AspNetUsers.Id
                          WHERE LiftId = :id
                          """;
        cmd.Parameters.AddWithValue(":id", liftId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var userId = reader.GetString(0);
            var guestId = reader.GetString(1);
            var bookedAt = reader.GetInt32(2);
            var acknowledgedAt = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
            var acknowledgedAtDateTime = acknowledgedAt.HasValue ? new DateTime(acknowledgedAt.Value, DateTimeKind.Utc) : (DateTime?)null;
            var firstName = reader.GetString(4);
            var lastName = reader.GetString(5);
            var userEmail = reader.GetString(6);
            bookings.Add(new SharedLiftBooking(userId, userEmail, $"{firstName} {lastName}", new DateTime(bookedAt, DateTimeKind.Utc), acknowledgedAtDateTime, guestId));
        }

        // Get non-guest bookings
        cmd = connection.CreateCommand();
        cmd.CommandText = """
                          SELECT UserId, PassengerName, BookedAt, AcknowledgedAt, AspNetUsers.Email
                          FROM SharedLiftNonGuestBookings
                          INNER JOIN AspNetUsers ON SharedLiftNonGuestBookings.UserId = AspNetUsers.Id
                          WHERE LiftId = :id
                          """;
        cmd.Parameters.AddWithValue(":id", liftId);
        using var reader2 = cmd.ExecuteReader();
        while (reader2.Read())
        {
            var userId = reader2.GetString(0);
            var passengerName = reader2.GetString(1);
            var bookedAt = reader2.GetInt32(2);
            var acknowledgedAt = reader2.IsDBNull(3) ? (int?)null : reader2.GetInt32(3);
            var acknowledgedAtDateTime = acknowledgedAt.HasValue ? new DateTime(acknowledgedAt.Value, DateTimeKind.Utc) : (DateTime?)null;
            var userEmail = reader2.GetString(4);
            bookings.Add(new SharedLiftBooking(userId, userEmail, passengerName, new DateTime(bookedAt, DateTimeKind.Utc), acknowledgedAtDateTime));
        }

        return bookings;
    }

    public IEnumerable<ISharedLift> GetAllLifts()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var lifts = new List<ISharedLift>();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = """
                          SELECT SharedLifts.Id, UserId, Name, Spaces, StartLocation, StartTime, EndLocation, EndTime, Notes, AspNetUsers.Email, COALESCE(GuestBookingCounts.GuestBookings, 0) + COALESCE(NonGuestBookingCounts.NonGuestBookings, 0) AS TotalBookings
                          FROM SharedLifts
                          INNER JOIN AspNetUsers ON SharedLifts.UserId = AspNetUsers.Id
                          LEFT JOIN (SELECT LiftId, COUNT(*) As GuestBookings FROM SharedLiftGuestBookings GROUP BY LiftId) AS GuestBookingCounts ON SharedLifts.Id = GuestBookingCounts.LiftId
                          LEFT JOIN (SELECT LiftId, COUNT(*) As NonGuestBookings FROM SharedLiftNonGuestBookings GROUP BY LiftId) AS NonGuestBookingCounts ON SharedLifts.Id = NonGuestBookingCounts.LiftId
                          """;
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var liftId = reader.GetString(0);
            var userId = reader.GetString(1);
            var name = reader.GetString(2);
            var spaces = reader.GetInt32(3);
            var startLocation = reader.GetString(4);
            var startTime = new DateTime(reader.GetInt64(5), DateTimeKind.Utc);
            var endLocation = reader.GetString(6);
            var endTime = new DateTime(reader.GetInt64(7), DateTimeKind.Utc);
            var notes = reader.GetString(8);
            var userEmail = reader.GetString(9);
            var numBookings = reader.GetInt32(10);
            
            lifts.Add(new SharedLift(liftId, userId, userEmail, name, spaces, numBookings, new JourneyEndpoint(startLocation, startTime), new JourneyEndpoint(endLocation, endTime), notes));
        }

        return lifts;
    }

    public bool BookLiftGuest(string liftId, string userId, string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var availableSpaces = GetNumSpaces(liftId, connection, transaction);
        if (availableSpaces <= 0)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = """
            INSERT INTO SharedLiftGuestBookings (LiftId, UserId, GuestId, BookedAt)
            VALUES (:liftId, :userId, :guestId, :bookedAt)
        """;
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":guestId", guestId);
        cmd.Parameters.AddWithValue(":bookedAt", DateTime.UtcNow.Ticks);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }

    public bool BookLiftNonGuest(string liftId, string userId, string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var availableSpaces = GetNumSpaces(liftId, connection, transaction);
        if (availableSpaces <= 0)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = """
            INSERT INTO SharedLiftNonGuestBookings (LiftId, UserId, PassengerName, BookedAt)
            VALUES (:liftId, :userId, :passengerName, :bookedAt)
        """;
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":passengerName", guestId);
        cmd.Parameters.AddWithValue(":bookedAt", DateTime.UtcNow.Ticks);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }
    
    public void CancelGuestBooking(string userId, string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM SharedLiftGuestBookings WHERE UserId = :userId AND GuestId = :guestId";
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":guestId", guestId);
        cmd.ExecuteNonQuery();
    }
    
    public void CancelNonGuestBooking(string userId, string name)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM SharedLiftNonGuestBookings WHERE UserId = :userId AND PassengerName = :name";
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":name", name);
        cmd.ExecuteNonQuery();
    }

    public void RequestLiftGuest(string userId, string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO SharedLiftGuestBookings (UserId, GuestId, BookedAt) VALUES (:userId, :guestId, :bookedAt)";
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":guestId", guestId);
        cmd.ExecuteNonQuery();
    }
    
    public void RequestLiftNonGuest(string userId, string name)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO SharedLiftNonGuestBookings (UserId, PassengerName, BookedAt) VALUES (:userId, :name, :bookedAt)";
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":name", name);
        cmd.ExecuteNonQuery();
    }

    public IEnumerable<SharedLiftBooking> GetAllLiftRequests()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var requests = new List<SharedLiftBooking>();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = """
            SELECT UserId, GuestId, BookedAt, AcknowledgedAt
            FROM SharedLiftGuestBookings
            WHERE LiftId IS NULL
        """;
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var userId = reader.GetString(0);
            var guestId = reader.GetString(1);
            var bookedAt = new DateTime(reader.GetInt32(2), DateTimeKind.Utc);
            var acknowledgedAt = reader.IsDBNull(3) ? (DateTime?)null : new DateTime(reader.GetInt32(3), DateTimeKind.Utc);
            requests.Add(new SharedLiftBooking(userId, "", "", bookedAt, acknowledgedAt, guestId));
        }
        
        cmd = connection.CreateCommand();
        cmd.CommandText = """
            SELECT UserId, PassengerName, BookedAt, AcknowledgedAt
            FROM SharedLiftNonGuestBookings
            WHERE LiftId IS NULL
        """;
        using var reader2 = cmd.ExecuteReader();
        while (reader2.Read())
        {
            var userId = reader2.GetString(0);
            var passengerName = reader2.GetString(1);
            var bookedAt = new DateTime(reader2.GetInt32(2), DateTimeKind.Utc);
            var acknowledgedAt = reader2.IsDBNull(3) ? (DateTime?)null : new DateTime(reader2.GetInt32(3), DateTimeKind.Utc);
            requests.Add(new SharedLiftBooking(userId, "", passengerName, bookedAt, acknowledgedAt));
        }
        
        return requests;
    }

    public bool AssignLiftGuest(string userId, string guestId, string liftId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var availableSpaces = GetNumSpaces(liftId, connection, transaction);
        if (availableSpaces <= 0)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "UPDATE SharedLiftGuestBookings SET LiftId = :liftId WHERE UserId = :userId AND GuestId = :guestId";
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":guestId", guestId);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }
    
    public bool AssignLiftNonGuest(string userId, string guestId, string liftId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var availableSpaces = GetNumSpaces(liftId, connection, transaction);
        if (availableSpaces <= 0)
        {
            return false;
        }
        
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = "UPDATE SharedLiftNonGuestBookings SET LiftId = :liftId WHERE UserId = :userId AND PassengerName = :passengerName";
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":passengerName", guestId);
        cmd.ExecuteNonQuery();
        
        transaction.Commit();
        return true;
    }
    
    public void AcknowledgeBookingGuest(string liftId, string userId, string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE SharedLiftGuestBookings SET AcknowledgedAt = :acknowledgedAt WHERE LiftId = :liftId AND UserId = :userId AND GuestId = :guestId";
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":guestId", guestId);
        cmd.Parameters.AddWithValue(":acknowledgedAt", DateTime.UtcNow.Ticks);
        cmd.ExecuteNonQuery();
    }
    
    public void AcknowledgeBookingNonGuest(string liftId, string userId, string name)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE SharedLiftNonGuestBookings SET AcknowledgedAt = :acknowledgedAt WHERE LiftId = :liftId AND UserId = :userId AND PassengerName = :name";
        cmd.Parameters.AddWithValue(":liftId", liftId);
        cmd.Parameters.AddWithValue(":userId", userId);
        cmd.Parameters.AddWithValue(":name", name);
        cmd.Parameters.AddWithValue(":acknowledgedAt", DateTime.UtcNow.Ticks);
        cmd.ExecuteNonQuery();
    }
}