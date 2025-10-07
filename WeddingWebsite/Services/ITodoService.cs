using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Services;

public interface ITodoService
{
    IEnumerable<IEnumerable<TodoItem>> GetGroupedTodoItems();
    void MarkItemAsCompleted(string itemId);
    void MarkItemAsWaiting(string itemId, TimeSpan waitingTime);
    void MarkItemAsActionRequired(string itemId);
    TodoItem? GetTodoItem(string itemId);
    void AddNewItem(string? groupId = null);
    void RenameItem(string itemId, string newText);
    void GroupItem(string itemId);
    void RemoveGroupFromItem(string itemId);
    void RenameGroup(string groupId, string newName);
    void DeleteItem(string itemId);
    void SetItemOwnerByEmail(string itemId, string? ownerEmail);
    IEnumerable<TodoItem> GetTodoItemsRequiringActionForGivenEmailOrNoEmail(string email);
}