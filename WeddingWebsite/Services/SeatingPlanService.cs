using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Services;

[Authorize]
public class SeatingPlanService(ISeatingPlanStore store) : ISeatingPlanService
{
    public SeatingPlanTable? GetTableForGuest(string guestId) => store.GetTableForGuest(guestId);
    public void SetTableForGuest(string guestId, string? tableId) => store.SetTableForGuest(guestId, tableId);
    public IEnumerable<SeatingPlanTable> GetAllTables() => store.GetAllTables();
    public IEnumerable<GuestWithTable> GetWholeSeatingPlan() => store.GetWholeSeatingPlan();
    public void RenameTable(string tableId, string newName) => store.RenameTable(tableId, newName);
    public void DeleteTable(string tableId) => store.DeleteTable(tableId);
    public string CreateTable(string tableName) => store.CreateTable(tableName);
}