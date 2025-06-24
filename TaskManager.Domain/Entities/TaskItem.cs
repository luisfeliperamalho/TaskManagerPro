namespace TaskManager.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem() { } // EF Core ou reconstrução

    public TaskItem(string title, string description, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted)
            throw new InvalidOperationException("Tarefa já está concluída.");

        IsCompleted = true;
    }
}
