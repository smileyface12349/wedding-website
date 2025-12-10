using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using WeddingWebsite.Core;
using WeddingWebsite.Data.Enums;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Stores;

public class Store : IStore
{
    [Authorize]
    public IEnumerable<GuestWithId> GetGuestsForUser(string userId)
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
        var guests = new List<GuestWithId>();
        while (reader.Read())
        {
            guests.Add(new GuestWithId(
                reader.GetString(0),
                new Name(reader.GetString(1), reader.GetString(2)),
                RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(reader.GetInt16(3))
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
                SELECT account.Id, account.Email, guest.FirstName, guest.LastName, guest.RsvpStatus, MAX(log.Timestamp) timestamp
                FROM AspNetUsers account
                LEFT JOIN Guests guest ON account.Id = guest.UserId
                LEFT JOIN AccountLog log ON account.Id = log.AffectedUserId AND log.EventType = :loginEventType
                GROUP BY account.Email, guest.GuestId
                ORDER BY account.Email
            """;
        
        command.Parameters.AddWithValue(":loginEventType", AccountLogTypeEnumConverter.AccountLogTypeToDatabaseInteger(AccountLogType.LogIn));
        
        using var reader = command.ExecuteReader();
        var accounts = new List<AccountWithGuests>();
        string? currentAccountId = null;
        string? currentAccountEmail = null;
        bool currentAccountHasLoggedIn = false;
        var currentGuests = new List<Guest>();
        
        while (reader.Read())
        {
            var accountId = reader.GetString(0);
            var accountEmail = reader.IsDBNull(1) ? null : reader.GetString(1);
            var guestFirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
            var guestLastName = reader.IsDBNull(3) ? null : reader.GetString(3);
            var guestRsvpStatus = reader.IsDBNull(4) ? RsvpStatus.NotResponded : RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(reader.GetInt16(4));
            var accountLastLoginTimestamp = reader.IsDBNull(5) ? (DateTime?)null : new DateTime(reader.GetInt64(5), DateTimeKind.Utc);
            
            if (currentAccountId != accountId)
            {
                if (currentAccountId != null)
                {
                    accounts.Add(new AccountWithGuests(currentGuests, currentAccountHasLoggedIn)
                    {
                        Id = currentAccountId,
                        Email = currentAccountEmail,
                    });
                }
                
                currentAccountId = accountId;
                currentAccountEmail = accountEmail;
                currentAccountHasLoggedIn = accountLastLoginTimestamp != null;
                currentGuests = new List<Guest>();
            }

            if (guestFirstName != null && guestLastName != null)
            {
                currentGuests.Add(new Guest(new Name(guestFirstName, guestLastName), guestRsvpStatus));
            }
        }
        
        if (currentAccountId != null)
        {
            accounts.Add(new AccountWithGuests(currentGuests, currentAccountHasLoggedIn)
            {
                Id = currentAccountId,
                Email = currentAccountEmail!
            });
        }
        
        return accounts;
    }

    [Authorize(Roles = "Admin")]
    public IEnumerable<GuestWithId> GetGuestsForAccount(string userId)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT GuestId, FirstName, LastName, RsvpStatus
                FROM Guests
                WHERE UserId = :userId
            """;
        command.Parameters.AddWithValue(":userId", userId);
        
        using var reader = command.ExecuteReader();
        var guests = new List<GuestWithId>();
        while (reader.Read())
        {
            var guestId = reader.GetString(0);
            var firstName = reader.GetString(1);
            var lastName = reader.GetString(2);
            var rsvpStatus = RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(reader.GetInt16(3));
            guests.Add(new GuestWithId(guestId, new Name(firstName, lastName), rsvpStatus));
        }

        return guests;
    }

    [Authorize(Roles = "Admin")]
    public void RenameGuest(string guestId, string newFirstName, string newLastName)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                UPDATE Guests
                SET FirstName = :newFirstName, LastName = :newLastName
                WHERE GuestId = :guestId
            """;
        
        command.Parameters.AddWithValue(":newFirstName", newFirstName);
        command.Parameters.AddWithValue(":newLastName", newLastName);
        command.Parameters.AddWithValue(":guestId", guestId);
        
        command.ExecuteNonQuery();
    }

    [Authorize(Roles = "Admin")]
    public void DeleteGuest(string guestId)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                DELETE FROM Guests
                WHERE GuestId = :guestId
            """;
        
        command.Parameters.AddWithValue(":guestId", guestId);
        
        command.ExecuteNonQuery();
    }

    [Authorize]
    public void AddAccountLog(string affectedUserId, string actorId, AccountLogType logType, string description)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                INSERT INTO AccountLog (LogId, Timestamp, AffectedUserId, ActorId, EventType, Description)
                VALUES (:logId, :timestamp, :affectedUserId, :actorId, :eventType, :description)
            """;
        
        command.Parameters.AddWithValue(":logId", Guid.NewGuid().ToString());
        command.Parameters.AddWithValue(":timestamp", DateTime.UtcNow.Ticks);
        command.Parameters.AddWithValue(":affectedUserId", affectedUserId);
        command.Parameters.AddWithValue(":actorId", actorId);
        command.Parameters.AddWithValue(":eventType", logType.ToDatabaseInteger());
        command.Parameters.AddWithValue(":description", description);
        
        command.ExecuteNonQuery();
    }
    
    public string? GetUserIdByEmail(string email)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT Id
                FROM AspNetUsers
                WHERE NormalizedEmail = :email
            """;
        
        command.Parameters.AddWithValue(":email", email.Normalize().ToUpperInvariant());
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var userId = reader.GetString(0);
            return userId;
        }
        
        return null;
    }

    [Authorize(Roles = "Admin")]
    public IEnumerable<AccountLog> GetAccountLogs(string userId)
    {
        using var connection = new SqliteConnection("DataSource=Data\\app.db;Cache=Shared");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT log.Timestamp, 
                       affectedUser.Id, affectedUser.Email, 
                       actor.Id, actor.Email, 
                       log.EventType, log.Description
                FROM AccountLog log
                JOIN AspNetUsers affectedUser ON log.AffectedUserId = affectedUser.Id
                JOIN AspNetUsers actor ON log.ActorId = actor.Id
                WHERE log.AffectedUserId = :userId
                ORDER BY log.Timestamp DESC
            """;
        
        command.Parameters.AddWithValue(":userId", userId);
        
        using var reader = command.ExecuteReader();
        var logs = new List<AccountLog>();
        while (reader.Read())
        {
            var timestampTicks = reader.GetInt64(0);
            var affectedUserId = reader.GetString(1);
            var affectedUserEmail = reader.GetString(2);
            var actorId = reader.GetString(3);
            var actorEmail = reader.GetString(4);
            var eventTypeInt = reader.GetInt16(5);
            
            var logType = AccountLogTypeEnumConverter.DatabaseIntegerToAccountLogType(eventTypeInt);
            
            var description = reader.IsDBNull(6) ? logType.GetEnumDescription() : reader.GetString(6);
            
            var log = new AccountLog(
                new DateTime(timestampTicks, DateTimeKind.Utc),
                new Account { Id = affectedUserId, Email = affectedUserEmail },
                new Account { Id = actorId, Email = actorEmail },
                logType,
                description
            );
            
            logs.Add(log);
        }

        return logs;
    }
}