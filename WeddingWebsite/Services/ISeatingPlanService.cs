using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Services;

public interface ISeatingPlanService
{
    /// <summary>
    /// Gets the table number for a specific guest. Null means not assigned to a table.
    /// </summary>
    public SeatingPlanTable? GetTableForGuest(string guestId);
    
    /// <summary>
    /// Sets the table number for a specific guest. Null will unassign them from any table.
    /// </summary>
    public void SetTableForGuest(string guestId, string? tableId);
    
    /// <summary>
    /// Get all the tables in the seating plan, including empty tables.
    /// </summary>
    public IEnumerable<SeatingPlanTable> GetAllTables();

    /// <summary>
    /// Gets all the tables and a list of guests with each one. Also outputs a table with ID empty string for guests
    /// that are not assigned to any table.
    /// </summary>
    public IEnumerable<GuestWithTable> GetWholeSeatingPlan();
    
    /// <summary>
    /// Rename a table. Doesn't affect who's assigned to what table.
    /// </summary>
    public void RenameTable(string tableId, string newName);
    
    /// <summary>
    /// Deletes a table. Guests assigned to that table will no longer be assigned to any table.
    /// </summary>
    public void DeleteTable(string tableId);
    
    /// <summary>
    /// Creates a new table with the given name. Returns the ID of the new table.
    /// </summary>
    public string CreateTable(string tableName);
}