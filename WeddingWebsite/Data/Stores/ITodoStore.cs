using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Data.Stores;

public interface ITodoStore
{
    void AddTodoItem(string id);
    void RenameTodoItem(string id, string newText);
    void SetTodoItemOwnerByEmail(string id, string ownerEmail);
    void SetTodoItemGroup(string id, string? groupId);
    void SetTodoItemWaitingUntil(string id, DateTime? waitingUntil);
    void SetTodoItemCompletedAt(string id, DateTime? completedAt);
    TodoItem? GetTodoItem(string id);
    IList<TodoItem> GetAllTodoItems();
    
    void AddTodoGroup(string id, string name);
    void RenameTodoGroup(string id, string newName);
    void RemoveTodoGroup(string id);
    TodoGroup? GetTodoGroup(string id);
}