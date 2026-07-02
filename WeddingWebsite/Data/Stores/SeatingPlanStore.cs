using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Stores;

[Authorize]
public class SeatingPlanStore : ISeatingPlanStore
{
    private const string ConnectionString = "DataSource=Data\\app.db;Cache=Shared";

    public SeatingPlanTable? GetTableForGuest(string guestId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT TableId, Name
                FROM SeatingPlan
                LEFT JOIN SeatingPlanTables ON SeatingPlan.TableId = SeatingPlanTables.Id
                WHERE GuestId = :guestId
            """;
        
        command.Parameters.AddWithValue(":guestId", guestId);
        
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var tableId = reader.GetString(0);
            var tableName = reader.GetString(1);
            return new SeatingPlanTable(tableId, tableName);
        }
        
        return null;
    }

    [Authorize(Roles = "Admin")]
    public void SetTableForGuest(string guestId, string? tableId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        if (tableId == null)
        {
            command.CommandText =
                """
                    DELETE FROM SeatingPlan
                    WHERE GuestId = :guestId
                """;
        }
        else
        {
            command.CommandText =
                """
                    INSERT INTO SeatingPlan (GuestId, TableId)
                    VALUES (:guestId, :table)
                    ON CONFLICT(GuestId) DO UPDATE SET TableId = :table
                """;
            command.Parameters.AddWithValue(":table", tableId);
        }

        command.Parameters.AddWithValue(":guestId", guestId);
        command.ExecuteNonQuery();
        
    }
    
    [Authorize(Roles = "Admin")]
    public IEnumerable<SeatingPlanTable> GetAllTables()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT Id, Name
                FROM SeatingPlanTables
                ORDER BY Name
            """;
        
        using var reader = command.ExecuteReader();
        var tables = new List<SeatingPlanTable>();
        while (reader.Read())
        {
            var tableId = reader.GetString(0);
            var tableName = reader.GetString(1);
            tables.Add(new SeatingPlanTable(tableId, tableName));
        }

        return tables;
    }
    
    public IEnumerable<GuestWithTable> GetWholeSeatingPlan()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                SELECT SeatingPlanTables.Id, SeatingPlanTables.Name, Guests.GuestId, Guests.FirstName, Guests.LastName
                FROM Guests
                LEFT JOIN SeatingPlan ON Guests.GuestId = SeatingPlan.GuestId
                LEFT JOIN SeatingPlanTables ON SeatingPlan.TableId = SeatingPlanTables.Id
                LEFT JOIN RsvpFormResponses ON Guests.GuestId = RsvpFormResponses.GuestId
                WHERE RsvpFormResponses.IsAttending = 1 OR RsvpFormResponses.IsAttending IS NULL
                ORDER BY SeatingPlanTables.Name, Guests.FirstName, Guests.LastName
            """;
        
        using var reader = command.ExecuteReader();
        var seatingPlan = new List<GuestWithTable>();
        while (reader.Read())
        {
            var tableId = reader.IsDBNull(0) ? "" : reader.GetString(0);
            var tableName = reader.IsDBNull(1) ? "" : reader.GetString(1);
            var guestId = reader.GetString(2);
            var firstName = reader.GetString(3);
            var lastName = reader.GetString(4);

            seatingPlan.Add(new GuestWithTable(guestId, new Name(firstName, lastName), RsvpStatus.NotResponded, tableId == "" ? null : new SeatingPlanTable(tableId, tableName)));
        }
        
        return seatingPlan;
    }

    [Authorize(Roles = "Admin")]
    public void RenameTable(string tableId, string newName)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                UPDATE SeatingPlanTables
                SET Name = :newName
                WHERE Id = :tableId
            """;
        command.Parameters.AddWithValue(":newName", newName);
        command.Parameters.AddWithValue(":tableId", tableId);
        command.ExecuteNonQuery();
    }

    [Authorize(Roles = "Admin")]
    public void DeleteTable(string tableId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                DELETE FROM SeatingPlanTables
                WHERE Id = :tableId
            """;
        command.Parameters.AddWithValue(":tableId", tableId);
        command.ExecuteNonQuery();
    }

    [Authorize(Roles = "Admin")]
    public string CreateTable(string tableName)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var tableId = Guid.NewGuid().ToString();
        
        var command = connection.CreateCommand();
        command.CommandText =
            """
                INSERT INTO SeatingPlanTables (Id, Name)
                VALUES (:tableId, :tableName)
            """;
        command.Parameters.AddWithValue(":tableId", tableId);
        command.Parameters.AddWithValue(":tableName", tableName);
        command.ExecuteNonQuery();
        
        return tableId;
    }
}