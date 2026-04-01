using Microsoft.Data.Sqlite;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Enums;
using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Data.Stores;

[Authorize]
public class RegistryStore : IRegistryStore
{
    private const string ConnectionString = "DataSource=Data\\app.db;Cache=Shared";
    
    [Authorize (Roles = "Admin")]
    public void AddItem(RegistryItem item)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = @"
            INSERT INTO RegistryItems (Id, GenericName, Name, Description, ImageUrl, MaxQuantity, Priority, Hide, Cost, AllowDeliverToUs, AllowBringOnDay, AllowMoneyTransfer)
            VALUES (:id, :genericName, :name, :description, :imageUrl, :maxQuantity, :priority, :hide, :cost, :allowDeliverToUs, :allowBringOnDay, :allowMoneyTransfer);
        ";
        cmd.Parameters.AddWithValue(":id", item.Id);
        cmd.Parameters.AddWithValue(":genericName", item.GenericName);
        cmd.Parameters.AddWithValue(":name", item.Name);
        cmd.Parameters.AddWithValue(":description", item.Description ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue(":imageUrl", item.ImageUrl ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue(":maxQuantity", item.MaxQuantity);
        cmd.Parameters.AddWithValue(":priority", item.Priority);
        cmd.Parameters.AddWithValue(":hide", item.Hide ? 1 : 0);
        cmd.Parameters.AddWithValue(":cost", item.Cost);
        cmd.Parameters.AddWithValue(":allowDeliverToUs", item.AllowDeliverToUs ? 1 : 0);
        cmd.Parameters.AddWithValue(":allowBringOnDay", item.AllowBringOnDay ? 1 : 0);
        cmd.Parameters.AddWithValue(":allowMoneyTransfer", item.AllowMoneyTransfer ? 1 : 0);

        cmd.ExecuteNonQuery();

        AddPurchaseMethods(item, connection, transaction);

        transaction.Commit();
    }

    [Authorize (Roles = "Admin")]
    private void AddPurchaseMethods(RegistryItem registryItem, SqliteConnection connection, SqliteTransaction transaction)
    {
        foreach (var method in registryItem.PurchaseMethods)
        {
            var methodCmd = connection.CreateCommand();
            methodCmd.Transaction = transaction;
            methodCmd.CommandText = @"
                INSERT INTO RegistryItemPurchaseMethods
                (Id, ItemId, Name, Cost, Url, DeliveryCost)
                VALUES
                (:id, :itemId, :name, :cost, :url, :deliveryCost);
            ";
            methodCmd.Parameters.AddWithValue(":id", method.Id);
            methodCmd.Parameters.AddWithValue(":itemId", registryItem.Id);
            methodCmd.Parameters.AddWithValue(":name", method.Name);
            methodCmd.Parameters.AddWithValue(":cost", method.Cost);
            methodCmd.Parameters.AddWithValue(":url", method.Url ?? (object)DBNull.Value);
            methodCmd.Parameters.AddWithValue(":deliveryCost", method.DeliveryCost);

            methodCmd.ExecuteNonQuery();
        }
    }

    [Authorize (Roles = "Admin")]
    public void UpdateItem(RegistryItem item)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        using var transaction = connection.BeginTransaction();
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = @"
            UPDATE RegistryItems
            SET GenericName = :genericName,
                Name = :name,
                Description = :description,
                ImageUrl = :imageUrl,
                MaxQuantity = :maxQuantity,
                Priority = :priority,
                Hide = :hide,
                Cost = :cost,
                AllowDeliverToUs = :allowDeliverToUs,
                AllowBringOnDay = :allowBringOnDay,
                AllowMoneyTransfer = :allowMoneyTransfer
            WHERE Id = :id;
        ";
        cmd.Parameters.AddWithValue(":id", item.Id);
        cmd.Parameters.AddWithValue(":genericName", item.GenericName);
        cmd.Parameters.AddWithValue(":name", item.Name);
        cmd.Parameters.AddWithValue(":description", item.Description ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue(":imageUrl", item.ImageUrl ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue(":maxQuantity", item.MaxQuantity);
        cmd.Parameters.AddWithValue(":priority", item.Priority);
        cmd.Parameters.AddWithValue(":hide", item.Hide ? 1 : 0);
        cmd.Parameters.AddWithValue(":cost", item.Cost);
        cmd.Parameters.AddWithValue(":allowDeliverToUs", item.AllowDeliverToUs ? 1 : 0);
        cmd.Parameters.AddWithValue(":allowBringOnDay", item.AllowBringOnDay ? 1 : 0);
        cmd.Parameters.AddWithValue(":allowMoneyTransfer", item.AllowMoneyTransfer ? 1 : 0);

        var rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No registry item found with ID {item.Id}");
        }

        // Get IDs of existing purchase methods
        var existingMethodIds = new HashSet<string>();
        var getMethodsCmd = connection.CreateCommand();
        getMethodsCmd.Transaction = transaction;
        getMethodsCmd.CommandText = @"
            SELECT Id
            FROM RegistryItemPurchaseMethods
            WHERE ItemId = :itemId;
        ";
        getMethodsCmd.Parameters.AddWithValue(":itemId", item.Id);
        using var reader = getMethodsCmd.ExecuteReader();
        while (reader.Read())
        {
            existingMethodIds.Add(reader.GetString(0));
        }
        
        // Update or insert purchase methods
        foreach (var method in item.PurchaseMethods)
        {
            if (existingMethodIds.Contains(method.Id))
            {
                // Update existing method
                var updateCmd = connection.CreateCommand();
                updateCmd.Transaction = transaction;
                updateCmd.CommandText = @"
                    UPDATE RegistryItemPurchaseMethods
                    SET Name = :name,
                        Cost = :cost,
                        Url = :url,
                        DeliveryCost = :deliveryCost
                    WHERE Id = :id AND ItemId = :itemId;
                ";
                updateCmd.Parameters.AddWithValue(":id", method.Id);
                updateCmd.Parameters.AddWithValue(":itemId", item.Id);
                updateCmd.Parameters.AddWithValue(":name", method.Name);
                updateCmd.Parameters.AddWithValue(":cost", method.Cost);
                updateCmd.Parameters.AddWithValue(":url", method.Url ?? (object)DBNull.Value);
                updateCmd.Parameters.AddWithValue(":deliveryCost", method.DeliveryCost);
                updateCmd.ExecuteNonQuery();
            }
            else
            {
                // Insert new method
                var insertCmd = connection.CreateCommand();
                insertCmd.Transaction = transaction;
                insertCmd.CommandText = @"
                    INSERT INTO RegistryItemPurchaseMethods
                    (Id, ItemId, Name, Cost, Url, DeliveryCost)
                    VALUES
                    (:id, :itemId, :name, :cost, :url, :deliveryCost);
                ";
                insertCmd.Parameters.AddWithValue(":id", method.Id);
                insertCmd.Parameters.AddWithValue(":itemId", item.Id);
                insertCmd.Parameters.AddWithValue(":name", method.Name);
                insertCmd.Parameters.AddWithValue(":cost", method.Cost);
                insertCmd.Parameters.AddWithValue(":url", method.Url ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue(":deliveryCost", method.DeliveryCost);
                insertCmd.ExecuteNonQuery();
            }
            
            existingMethodIds.Remove(method.Id); // Mark as processed
        }
        
        // Delete removed purchase methods
        foreach (var methodId in existingMethodIds)
        {
            var deleteCmd = connection.CreateCommand();
            deleteCmd.Transaction = transaction;
            deleteCmd.CommandText = @"
                DELETE FROM RegistryItemPurchaseMethods
                WHERE Id = :id AND ItemId = :itemId;
            ";
            deleteCmd.Parameters.AddWithValue(":id", methodId);
            deleteCmd.Parameters.AddWithValue(":itemId", item.Id);
            deleteCmd.ExecuteNonQuery();
        }

        transaction.Commit();
    }
    
    [Authorize (Roles = "Admin")]
    public bool DeleteItem(string itemId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();
        var cmd = connection.CreateCommand();
        cmd.Transaction = transaction;
        cmd.CommandText = @"
            DELETE FROM RegistryItems
            WHERE Id = :id;
        ";
        cmd.Parameters.AddWithValue(":id", itemId);

        var rowsAffected = cmd.ExecuteNonQuery();
        transaction.Commit();

        return rowsAffected > 0;
    }
    
    public RegistryItem? GetRegistryItemById(string itemId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT Id, GenericName, Name, Description, ImageUrl, MaxQuantity, Priority, Hide, Cost, AllowBringOnDay, AllowDeliverToUs, AllowMoneyTransfer
            FROM RegistryItems
            WHERE Id = :id;
        ";
        cmd.Parameters.AddWithValue(":id", itemId);

        using var reader = cmd.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        var id = reader.GetString(0);
        var genericName = reader.GetString(1);
        var name = reader.GetString(2);
        var description = reader.IsDBNull(3) ? null : reader.GetString(3);
        var imageUrl = reader.IsDBNull(4) ? null : reader.GetString(4);
        var maxQuantity = reader.GetInt32(5);
        var priority = reader.GetInt32(6);
        var hide = reader.GetBoolean(7);
        var cost = reader.GetDecimal(8);
        var allowBringOnDay = reader.GetBoolean(9);
        var allowDeliverToUs = reader.GetBoolean(10);
        var allowMoneyTransfer = reader.GetBoolean(11);

        var purchaseMethods = GetPurchaseMethodsForItem(id, connection);
        var claims = GetClaimsForItem(id, connection);

        return new RegistryItem(
            id,
            genericName,
            name,
            description,
            imageUrl,
            cost,
            purchaseMethods,
            claims,
            maxQuantity,
            priority,
            hide,
            allowBringOnDay,
            allowDeliverToUs,
            allowMoneyTransfer
        );
    }

    private static List<RegistryItemPurchaseMethod> GetPurchaseMethodsForItem(string itemId, SqliteConnection connection)
    {
        var methods = new List<RegistryItemPurchaseMethod>();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT Id, Name, Cost, Url, DeliveryCost
            FROM RegistryItemPurchaseMethods
            WHERE ItemId = :itemId;
        ";
        cmd.Parameters.AddWithValue(":itemId", itemId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var method = new RegistryItemPurchaseMethod(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetDecimal(2),
                reader.IsDBNull(3) ? null : reader.GetString(3),
                reader.GetDecimal(4)
            );
            methods.Add(method);
        }

        return methods;
    }
    
    private static List<RegistryItemClaim> GetClaimsForItem(string itemId, SqliteConnection connection)
    {
        var claims = new List<RegistryItemClaim>();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT ItemId, ClaimedBy, FulfillmentMethod, Recipient, ClaimedAt, CompletedAt, ReceivedAt, Quantity, Notes
            FROM RegistryItemClaims
            WHERE ItemId = :itemId;
        ";
        cmd.Parameters.AddWithValue(":itemId", itemId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var claim = new RegistryItemClaim(
                reader.GetString(0),
                reader.GetString(1),
                reader.IsDBNull(2) ? null : FulfillmentMethodEnumConverter.DatabaseIntegerToFulfillmentMethod(reader.GetInt32(2)),
                reader.IsDBNull(3) ? null : reader.GetString(3),
                new DateTime(reader.GetInt64(4), DateTimeKind.Utc),
                reader.IsDBNull(5) ? null : new DateTime(reader.GetInt64(5), DateTimeKind.Utc),
                reader.IsDBNull(6) ? null : new DateTime(reader.GetInt64(6), DateTimeKind.Utc),
                reader.GetInt32(7),
                reader.IsDBNull(8) ? null : reader.GetString(8)
            );
            claims.Add(claim);
        }

        return claims;
    }
    
    public async Task<IEnumerable<RegistryItem>> GetAllRegistryItems(bool includeHidden = false)
    {
        var items = new List<RegistryItem>();

        await using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            SELECT Id, GenericName, Name, Description, ImageUrl, MaxQuantity, Priority, Hide, Cost, AllowDeliverToUs, AllowBringOnDay, AllowMoneyTransfer
            FROM RegistryItems
            " + (includeHidden ? "" : "WHERE Hide = 0 ") + @"
            ORDER BY Priority DESC, Name ASC;
        ";

        await using var reader = await cmd.ExecuteReaderAsync();
        while (reader.Read())
        {
            var id = reader.GetString(0);
            var genericName = reader.GetString(1);
            var name = reader.GetString(2);
            var description = reader.IsDBNull(3) ? null : reader.GetString(3);
            var imageUrl = reader.IsDBNull(4) ? null : reader.GetString(4);
            var maxQuantity = reader.GetInt32(5);
            var priority = reader.GetInt32(6);
            var hide = reader.GetBoolean(7);
            var cost = reader.GetDecimal(8);
            var allowDeliverToUs = reader.GetBoolean(9);
            var allowBringOnDay = reader.GetBoolean(10);
            var allowMoneyTransfer = reader.GetBoolean(11);

            var purchaseMethods = GetPurchaseMethodsForItem(id, connection);
            var claims = GetClaimsForItem(id, connection);

            var item = new RegistryItem(
                id,
                genericName,
                name,
                description,
                imageUrl,
                cost,
                purchaseMethods,
                claims,
                maxQuantity,
                priority,
                hide,
                AllowBringOnDay: allowBringOnDay,
                AllowDeliverToUs: allowDeliverToUs,
                AllowMoneyTransfer: allowMoneyTransfer
            );
            items.Add(item);
        }

        return items;
    }
    
    public bool ClaimRegistryItem(string itemId, string userId, int quantity = 1)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        // Check if item exists and get max quantity
        var itemCmd = connection.CreateCommand();
        itemCmd.Transaction = transaction;
        itemCmd.CommandText = @"
            SELECT MaxQuantity
            FROM RegistryItems
            WHERE Id = :id;
        ";
        itemCmd.Parameters.AddWithValue(":id", itemId);

        var maxQuantityObj = itemCmd.ExecuteScalar();
        if (maxQuantityObj == null)
        {
            throw new InvalidOperationException($"No registry item found with ID {itemId}");
        }
        var maxQuantity = Convert.ToInt32(maxQuantityObj);

        // Check current claimed quantity
        var claimCountCmd = connection.CreateCommand();
        claimCountCmd.Transaction = transaction;
        claimCountCmd.CommandText = @"
            SELECT SUM(Quantity)
            FROM RegistryItemClaims
            WHERE ItemId = :itemId;
        ";
        claimCountCmd.Parameters.AddWithValue(":itemId", itemId);

        var currentClaimedObj = claimCountCmd.ExecuteScalar();
        var currentClaimed = currentClaimedObj == DBNull.Value ? 0 : Convert.ToInt32(currentClaimedObj);

        if (currentClaimed + quantity > maxQuantity)
        {
            return false; // Exceeds max quantity
        }

        // Add the claim
        var claimCmd = connection.CreateCommand();
        claimCmd.Transaction = transaction;
        claimCmd.CommandText = @"
            INSERT INTO RegistryItemClaims
            (ItemId, ClaimedBy, FulfillmentMethod, Recipient, ClaimedAt, CompletedAt, ReceivedAt, Quantity, Notes)
            VALUES
            (:itemId, :claimedBy, NULL, NULL, :claimedAt, NULL, NULL, :quantity, NULL);
        ";
        claimCmd.Parameters.AddWithValue(":itemId", itemId);
        claimCmd.Parameters.AddWithValue(":claimedBy", userId);
        claimCmd.Parameters.AddWithValue(":claimedAt", DateTime.UtcNow.Ticks);
        claimCmd.Parameters.AddWithValue(":quantity", quantity);

        claimCmd.ExecuteNonQuery();

        transaction.Commit();
        return true;
    }
    
    public bool UnclaimRegistryItem(string itemId, string userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        // Check if claim exists and is not completed
        var checkCmd = connection.CreateCommand();
        checkCmd.Transaction = transaction;
        checkCmd.CommandText = @"
            SELECT CompletedAt
            FROM RegistryItemClaims
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy;
        ";
        checkCmd.Parameters.AddWithValue(":itemId", itemId);
        checkCmd.Parameters.AddWithValue(":claimedBy", userId);

        var completedAtObj = checkCmd.ExecuteScalar();
        if (completedAtObj == null)
        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId}");
        }
        if (completedAtObj != DBNull.Value)
        {
            return false; // Claim already completed
        }

        // Delete the claim
        var deleteCmd = connection.CreateCommand();
        deleteCmd.Transaction = transaction;
        deleteCmd.CommandText = @"
            DELETE FROM RegistryItemClaims
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy;
        ";
        deleteCmd.Parameters.AddWithValue(":itemId", itemId);
        deleteCmd.Parameters.AddWithValue(":claimedBy", userId);

        var rowsAffected = deleteCmd.ExecuteNonQuery();

        transaction.Commit();
        return rowsAffected == 1;
    }
    
    public void ChooseFulfillmentMethod(string itemId, string userId, FulfillmentMethod? fulfillmentMethod)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET FulfillmentMethod = :fulfillmentMethod, Recipient = NULL
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy;
        ";
        updateCmd.Parameters.AddWithValue(":fulfillmentMethod", fulfillmentMethod?.ToDatabaseInteger() ?? (object)DBNull.Value);
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);

        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId}");
        }
    }

    public void ChooseRecipient(string itemId, string userId, string? recipient)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET Recipient = :recipient
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy;
        ";
        updateCmd.Parameters.AddWithValue(":recipient", recipient ?? (object)DBNull.Value);
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);
        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId}");
        }
    }
    
    public void MarkClaimAsCompleted(string itemId, string userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET CompletedAt = :completedAt
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy AND CompletedAt IS NULL;
        ";
        updateCmd.Parameters.AddWithValue(":completedAt", DateTime.UtcNow.Ticks);
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);

        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No uncompleted claim found for item ID {itemId} by user {userId}");
        }
    }

    [Authorize(Roles = "Admin")]
    public void MarkClaimAsNotCompleted(string itemId, string userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET CompletedAt = NULL
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy AND CompletedAt IS NOT NULL;
        ";
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);

        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No completed claim found for item ID {itemId} by user {userId}");
        }
    }

    [Authorize(Roles = "Admin")]
    public void MarkClaimAsReceived(string itemId, string userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET ReceivedAt = :receivedAt
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy AND ReceivedAt IS NULL;
        ";
        updateCmd.Parameters.AddWithValue(":receivedAt", DateTime.UtcNow.Ticks);
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);
        
        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId} that is not already marked as received");
        }
    }

    [Authorize(Roles = "Admin")]
    public void MarkClaimAsNotReceived(string itemId, string userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET ReceivedAt = NULL
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy AND ReceivedAt IS NOT NULL;
        ";
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);
        
        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId} that is currently marked as received");
        }
    }

    public void SetClaimNotes(string itemId, string userId, string? notes)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var updateCmd = connection.CreateCommand();
        updateCmd.CommandText = @"
            UPDATE RegistryItemClaims
            SET Notes = :notes
            WHERE ItemId = :itemId AND ClaimedBy = :claimedBy;
        ";
        updateCmd.Parameters.AddWithValue(":notes", notes ?? (object)DBNull.Value);
        updateCmd.Parameters.AddWithValue(":itemId", itemId);
        updateCmd.Parameters.AddWithValue(":claimedBy", userId);

        var rowsAffected = updateCmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"No claim found for item ID {itemId} by user {userId}");
        }
    }
}