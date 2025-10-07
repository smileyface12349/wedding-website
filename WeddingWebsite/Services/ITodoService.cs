using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Services;

public interface ITodoService
{
    IEnumerable<IEnumerable<TodoItem>> GetGroupedTodoItems();
    
}