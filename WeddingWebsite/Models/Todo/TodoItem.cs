namespace WeddingWebsite.Models.Todo;

public record TodoItem(
    string Id,
    string? OwnerEmail,
    string Text,
    TodoGroup? Group,
    DateTime? WaitingUntil = null,
    DateTime? CompletedAt = null
)
{
    public TodoItemStatus Status
    {
        get
        {
            if (CompletedAt.HasValue)
                return TodoItemStatus.Completed;
            if (WaitingUntil.HasValue && WaitingUntil.Value > DateTime.UtcNow)
                return TodoItemStatus.Waiting;
            return TodoItemStatus.ActionRequired;
        }
    }
}