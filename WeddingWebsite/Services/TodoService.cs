using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Services;

public class TodoService(ITodoStore todoStore, IStore store) : ITodoService
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
    
    public void MarkItemAsActionRequired(string itemId)
    {
        todoStore.SetTodoItemWaitingUntil(itemId, null);
        todoStore.SetTodoItemCompletedAt(itemId, null);
    }
    
    public TodoItem? GetTodoItem(string itemId)
    {
        return todoStore.GetTodoItem(itemId);
    }

    public void AddNewItem(string? groupId = null)
    {
        var newId = Guid.NewGuid().ToString();
        todoStore.AddTodoItem(newId);
        if (groupId != null)
        {
            todoStore.SetTodoItemGroup(newId, groupId);
        }
    }
    
    public void RenameItem(string itemId, string newText)
    {
        todoStore.RenameTodoItem(itemId, newText);
    }

    public void GroupItem(string itemId)
    {
        var groupId = Guid.NewGuid().ToString();
        todoStore.AddTodoGroup(groupId, "Todo Group");
        todoStore.SetTodoItemGroup(itemId, groupId);
    }
    
    public void RemoveGroupFromItem(string itemId)
    {
        var item = todoStore.GetTodoItem(itemId);
        if (item?.Group != null)
        {
            var groupId = item.Group.Id;
            todoStore.SetTodoItemGroup(itemId, null);
            var allItems = todoStore.GetAllTodoItems();
            if (allItems.All(i => i.Group?.Id != groupId))
            {
                todoStore.RemoveTodoGroup(groupId);
            }
        }
    }
    
    public void RenameGroup(string groupId, string newName)
    {
        todoStore.RenameTodoGroup(groupId, newName);
    }

    public void DeleteItem(string itemId)
    {
        todoStore.DeleteTodoItem(itemId);
    }
    
    public void SetItemOwnerByEmail(string itemId, string? ownerEmail)
    {
        string? ownerId = null;
        if (ownerEmail != null)
        {
            ownerId = store.GetUserIdByEmail(ownerEmail);
        }
        todoStore.SetTodoItemOwner(itemId, ownerId);
    }
    
    public IEnumerable<TodoItem> GetTodoItemsRequiringActionForGivenEmailOrNoEmail(string email)
    {
        var allItems = todoStore.GetAllTodoItems();
        return allItems
            .Where(item => item.OwnerEmail == null || item.OwnerEmail == email)
            .Where(item => item.Status == TodoItemStatus.ActionRequired);
    }
}