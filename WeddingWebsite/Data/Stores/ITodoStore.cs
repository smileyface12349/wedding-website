using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Data.Stores;

public interface ITodoStore
{
    void AddTodoItem(string id);
    void RenameTodoItem(string id, string newText);
    void SetTodoItemOwner(string id, string? ownerId);
    void SetTodoItemGroup(string id, string? groupId);
    void SetTodoItemWaitingUntil(string id, DateTime? waitingUntil);
    void SetTodoItemCompletedAt(string id, DateTime? completedAt);
    TodoItem? GetTodoItem(string id);
    IList<TodoItem> GetAllTodoItems();
    void DeleteTodoItem(string id);
    
    void AddTodoGroup(string id, string name);
    void RenameTodoGroup(string id, string newName);
    void RemoveTodoGroup(string id);
    TodoGroup? GetTodoGroup(string id);
}