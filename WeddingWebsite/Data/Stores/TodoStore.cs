using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Data.Stores;

[Authorize(Roles = "Admin")]
public class TodoStore : ITodoStore
{
    private const string ConnectionString = "DataSource=Data\\app.db;Cache=Shared";

    public void AddTodoItem(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO TodoItems (Id) VALUES (:id)";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.ExecuteNonQuery();
    }

    public void RenameTodoItem(string id, string newText)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET Text = :text WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":text", newText);
        cmd.ExecuteNonQuery();
    }

    public void SetTodoItemOwner(string id, string? ownerId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET OwnerId = :ownerId WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":ownerId", ownerId == null ? DBNull.Value : ownerId);
        cmd.ExecuteNonQuery();
    }
    
    public void SetTodoItemGroup(string id, string? groupId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET GroupId = :groupId WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":groupId", groupId == null ? DBNull.Value : groupId);
        cmd.ExecuteNonQuery();
    }
    
    public void SetTodoItemWaitingUntil(string id, DateTime? waitingUntil)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET WaitingUntil = :waitingUntil WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":waitingUntil", waitingUntil == null ? DBNull.Value : waitingUntil);
        cmd.ExecuteNonQuery();
    }
    
    public void SetTodoItemCompletedAt(string id, DateTime? completedAt)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET CompletedAt = :completedAt WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":completedAt", completedAt == null ? DBNull.Value : completedAt);
        cmd.ExecuteNonQuery();
    }

    public TodoItem? GetTodoItem(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT 
                ti.Id, 
                u.Email AS OwnerEmail, 
                ti.Text, 
                tg.Id AS GroupId, 
                tg.Name AS GroupName, 
                ti.WaitingUntil, 
                ti.CompletedAt
            FROM TodoItems ti
            LEFT JOIN AspNetUsers u ON ti.OwnerId = u.Id
            LEFT JOIN TodoGroups tg ON ti.GroupId = tg.Id
            WHERE ti.Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var itemId = reader.GetString(0);
            var ownerEmail = reader.IsDBNull(1) ? null : reader.GetString(1);
            var text = reader.IsDBNull(2) ? null : reader.GetString(2);
            var groupId = reader.IsDBNull(3) ? null : reader.GetString(3);
            var groupName = reader.IsDBNull(4) ? null : reader.GetString(4);
            DateTime? waitingUntil = reader.IsDBNull(5) ? null : reader.GetDateTime(5);
            DateTime? completedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6);

            TodoGroup? group = groupId != null && groupName != null ? new TodoGroup(groupId, groupName) : null;

            return new TodoItem(itemId, ownerEmail, text, group, waitingUntil, completedAt);
        }

        return null;
    }
    
    public IList<TodoItem> GetAllTodoItems()
    {
        var items = new List<TodoItem>();
        
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT 
                ti.Id, 
                u.Email AS OwnerEmail, 
                ti.Text, 
                tg.Id AS GroupId, 
                tg.Name AS GroupName, 
                ti.WaitingUntil, 
                ti.CompletedAt
            FROM TodoItems ti
            LEFT JOIN AspNetUsers u ON ti.OwnerId = u.Id
            LEFT JOIN TodoGroups tg ON ti.GroupId = tg.Id
            ORDER BY 
                CASE 
                    WHEN ti.CompletedAt IS NOT NULL THEN 2
                    WHEN ti.WaitingUntil IS NOT NULL AND ti.WaitingUntil > CURRENT_TIMESTAMP THEN 1
                    ELSE 0
                END,
                ti.WaitingUntil,
                ti.Text";
        
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var itemId = reader.GetString(0);
            var ownerEmail = reader.IsDBNull(1) ? null : reader.GetString(1);
            var text = reader.IsDBNull(2) ? null : reader.GetString(2);
            var groupId = reader.IsDBNull(3) ? null : reader.GetString(3);
            var groupName = reader.IsDBNull(4) ? null : reader.GetString(4);
            DateTime? waitingUntil = reader.IsDBNull(5) ? null : reader.GetDateTime(5);
            DateTime? completedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6);

            TodoGroup? group = groupId != null && groupName != null ? new TodoGroup(groupId, groupName) : null;

            items.Add(new TodoItem(itemId, ownerEmail, text, group, waitingUntil, completedAt));
        }

        return items;
    }

    public void DeleteTodoItem(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM TodoItems WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.ExecuteNonQuery();
    }

    public void AddTodoGroup(string id, string name)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO TodoGroups (Id, Name) VALUES (:id, :name)";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":name", name);
        cmd.ExecuteNonQuery();
    }
    
    public void RenameTodoGroup(string id, string newName)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE TodoGroups SET Name = :name WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.Parameters.AddWithValue(":name", newName);
        cmd.ExecuteNonQuery();
    }
    
    public void RemoveTodoGroup(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM TodoGroups WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        cmd.ExecuteNonQuery();
    }
    
    public TodoGroup? GetTodoGroup(string id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Id, Name FROM TodoGroups WHERE Id = :id";
        cmd.Parameters.AddWithValue(":id", id);
        
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var groupId = reader.GetString(0);
            var groupName = reader.IsDBNull(1) ? null : reader.GetString(1);
            return new TodoGroup(groupId, groupName ?? "");
        }

        return null;
    }
}