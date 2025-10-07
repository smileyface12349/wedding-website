using WeddingWebsite.Models.Todo;

namespace WeddingWebsite.Core;

public static class EnumerableExtensions
{
    public static TodoGroup? GetGroup(this IEnumerable<TodoItem> items)
    {
        return items.FirstOrDefault()?.Group;
    }
}