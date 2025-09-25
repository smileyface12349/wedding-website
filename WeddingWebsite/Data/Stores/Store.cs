using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using WeddingWebsite.Data.Enums;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Stores;

public class Store : IStore
{
    [Authorize]
    public IEnumerable<GuestResponse> GetGuestsForUser(string userId)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT GuestId, FirstName, LastName, RsvpStatus
            FROM Guests
            WHERE UserId = :userId
        ";
        command.Parameters.AddWithValue(":userId", userId);

        using var reader = command.ExecuteReader();
        var guests = new List<GuestResponse>();
        while (reader.Read())
        {
            guests.Add(new GuestResponse(
                userId,
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt16(3)
            ));
        }

        return guests;
    }
    
    [Authorize(Roles = "Admin")]
    public void AddGuestToAccount(string userId, string firstName, string lastName)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            INSERT INTO Guests (GuestId, UserId, FirstName, LastName, RsvpStatus)
            VALUES (:guestId, :userId, :firstName, :lastName, :rsvpStatus)
        ";
        command.Parameters.AddWithValue(":guestId", Guid.NewGuid().ToString());
        command.Parameters.AddWithValue(":userId", userId);
        command.Parameters.AddWithValue(":firstName", firstName);
        command.Parameters.AddWithValue(":lastName", lastName);
        command.Parameters.AddWithValue(":rsvpStatus", RsvpStatusEnumConverter.RsvpStatusToDatabaseInteger(RsvpStatus.NotResponded));

        command.ExecuteNonQuery();
    }
}