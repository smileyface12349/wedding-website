using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Services;

public class TodoService(ITodoStore todoStore) : ITodoService
{
    public IEnumerable<IEnumerable<TodoItem>> GetGroupedTodoItems()
    {
        var todoItems = todoStore.GetAllTodoItems();
        
        var groupedItems = todoItems
            .Where(item => item.Group != null)
            .GroupBy(item => item.Group!.Id)
            .Select(group => group.ToList())
            .Concat(
                todoItems
                    .Where(item => item.Group == null)
                    .Select(item => new List<TodoItem> { item })
            );
        
        return groupedItems;
    }
    
    public void MarkItemAsCompleted(string itemId)
    {
        todoStore.SetTodoItemCompletedAt(itemId, DateTime.UtcNow);
    }
    
    public void MarkItemAsWaiting(string itemId, TimeSpan waitingTime)
    {
        todoStore.SetTodoItemWaitingUntil(itemId, DateTime.UtcNow.Add(waitingTime));
    }
}