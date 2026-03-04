using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Stores;

public class RsvpStore : IRsvpStore
{
    private const string ConnectionString = "DataSource=Data\\app.db;Cache=Shared";
    
    [Authorize]
    public bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> rsvpData)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        // Check if the user has already RSVPed
        var checkCommand = connection.CreateCommand();
        checkCommand.CommandText = "SELECT GuestId FROM RsvpFormResponses WHERE GuestId = :guestId";
        checkCommand.Parameters.AddWithValue(":guestId", guestId);
        using var reader = checkCommand.ExecuteReader();
        while (reader.Read())
        {
            return false;
        }

        // Insert the RSVP data
        var insertCommand = connection.CreateCommand();
        insertCommand.CommandText = @"
            INSERT INTO RsvpFormResponses (GuestId, SubmittedAt, IsAttending, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10,
                                       Data11, Data12, Data13, Data14, Data15, Data16, Data17, Data18, Data19, Data20)
            VALUES ($guestId, $submittedAt, $isAttending, $data0, $data1, $data2, $data3, $data4, $data5, $data6, $data7, $data8, $data9, $data10,
                    $data11, $data12, $data13, $data14, $data15, $data16, $data17, $data18, $data19, $data20)";
        
        insertCommand.Parameters.AddWithValue("guestId", guestId);
        insertCommand.Parameters.AddWithValue("isAttending", isAttending ? 1 : 0);
        insertCommand.Parameters.AddWithValue("submittedAt", DateTime.UtcNow);
        
        for (int i = 0; i <= 20; i++)
        {
            var paramName = $"data{i}";
            var dataValue = rsvpData.ElementAtOrDefault(i);
            insertCommand.Parameters.AddWithValue(paramName, (object?) dataValue ?? DBNull.Value);
        }

        var rowsUpdated = insertCommand.ExecuteNonQuery();
        Console.WriteLine($"Rows updated: {rowsUpdated}");
        return rowsUpdated == 1;
    }

    [Authorize]
    public RsvpResponseData? GetRsvp(string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var selectCommand = connection.CreateCommand();
        selectCommand.CommandText = @"
            SELECT SubmittedAt, IsAttending, Guests.FirstName, Guests.LastName, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10,
                   Data11, Data12, Data13, Data14, Data15, Data16, Data17, Data18, Data19, Data20
            FROM RsvpFormResponses
            LEFT JOIN Guests on RsvpFormResponses.GuestId = Guests.GuestId
            WHERE RsvpFormResponses.GuestId = $guestId";
        
        selectCommand.Parameters.AddWithValue("guestId", guestId);

        using var reader = selectCommand.ExecuteReader();
        if (!reader.Read())
        {
            return null; // No RSVP found
        }

        var submittedAt = reader.GetDateTime(0);
        var isAttending = reader.GetInt32(1) == 1;
        var firstName = reader.GetString(2);
        var lastName = reader.GetString(3);
        var rsvpData = new List<string?>();
        
        for (int i = 0; i <= 20; i++)
        {
            if (reader.IsDBNull(i+4))
            {
                rsvpData.Add(null);
            }
            else
            {
                rsvpData.Add(reader.GetString(i+3));
            }
        }

        return new RsvpResponseData(guestId, new Name(firstName, lastName), submittedAt, isAttending, rsvpData);
    }

    [Authorize(Roles = "Admin")]
    public IEnumerable<RsvpResponseData> GetAllRsvps()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var selectCommand = connection.CreateCommand();
        selectCommand.CommandText = @"
            SELECT RsvpFormResponses.GuestId, SubmittedAt, IsAttending, Guests.FirstName, Guests.LastName, Data0, Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10,
                   Data11, Data12, Data13, Data14, Data15, Data16, Data17, Data18, Data19, Data20
            FROM RsvpFormResponses
            LEFT JOIN Guests on RsvpFormResponses.GuestId = Guests.GuestId";

        using var reader = selectCommand.ExecuteReader();
        while (reader.Read())
        {
            var guestId = reader.GetString(0);
            var submittedAt = reader.GetDateTime(1);
            var isAttending = reader.GetInt32(2) == 1;
            var firstName = reader.GetString(3);
            var lastName = reader.GetString(4);
            var rsvpData = new List<string?>();
            
            for (int i = 0; i <= 20; i++)
            {
                if (reader.IsDBNull(i+5))
                {
                    rsvpData.Add(null);
                }
                else
                {
                    rsvpData.Add(reader.GetString(i+5));
                }
            }

            yield return new RsvpResponseData(guestId, new Name(firstName, lastName), submittedAt, isAttending, rsvpData);
        }
    }

    [Authorize(Roles = "Admin")]
    public void DeleteRsvp(string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var deleteCommand = connection.CreateCommand();
        deleteCommand.CommandText = "DELETE FROM RsvpFormResponses WHERE GuestId = $guestId";
        deleteCommand.Parameters.AddWithValue("guestId", guestId);

        deleteCommand.ExecuteNonQuery();
    }
}