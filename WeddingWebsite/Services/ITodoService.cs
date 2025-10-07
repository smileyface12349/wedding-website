using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Services;

public interface ITodoService
{
    IEnumerable<IEnumerable<TodoItem>> GetGroupedTodoItems();
    void MarkItemAsCompleted(string itemId);
    void MarkItemAsWaiting(string itemId, TimeSpan waitingTime);
}