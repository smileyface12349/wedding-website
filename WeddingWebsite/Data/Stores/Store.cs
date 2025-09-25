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

    [Authorize(Roles = "Admin")]
    public IEnumerable<AccountWithGuests> GetAllAccounts()
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = 
            """
                SELECT account.Id, account.Email, guest.FirstName, guest.LastName, guest.RsvpStatus
                FROM AspNetUsers account
                LEFT JOIN Guests guest ON account.Id = guest.UserId
                ORDER BY account.Email
            """;
        
        using var reader = command.ExecuteReader();
        var accounts = new List<AccountWithGuests>();
        string? currentAccountId = null;
        string? currentAccountEmail = null;
        var currentGuests = new List<Guest>();
        
        while (reader.Read())
        {
            var accountId = reader.GetString(0);
            var accountEmail = reader.GetString(1);
            var guestFirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
            var guestLastName = reader.IsDBNull(3) ? null : reader.GetString(3);
            var guestRsvpStatus = reader.IsDBNull(4) ? RsvpStatus.NotResponded : RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(reader.GetInt16(4));

            if (currentAccountId != accountId)
            {
                if (currentAccountId != null)
                {
                    accounts.Add(new AccountWithGuests(currentGuests)
                    {
                        Id = currentAccountId,
                        Email = currentAccountEmail!
                    });
                }
                
                currentAccountId = accountId;
                currentAccountEmail = accountEmail;
                currentGuests = new List<Guest>();
            }

            if (guestFirstName != null && guestLastName != null)
            {
                currentGuests.Add(new Guest(new Name(guestFirstName, guestLastName), guestRsvpStatus));
            }
        }

        return accounts;
    }
}