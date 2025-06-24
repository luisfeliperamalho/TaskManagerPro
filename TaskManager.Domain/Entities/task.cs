namespace TaskManagerPro.Domain.Entities;

public class Task
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsCompleted { get; private set; }

    protected Task() { } // EF Core ou reconstrução

    public Task(string title, string description, DateTime dueDate)
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
