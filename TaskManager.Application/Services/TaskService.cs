public class TaskService : ITaskService
{
    private static readonly List<TaskDto> _tasks = new();

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
        return await Task.FromResult(_tasks);
    }

    public async Task<TaskDto?> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task<TaskDto> CreateAsync(TaskDto taskDto)
    {
        taskDto.Id = Guid.NewGuid();
        _tasks.Add(taskDto);
        return await Task.FromResult(taskDto);
    }

    public async Task<bool> UpdateAsync(Guid id, TaskDto taskDto)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == id);
        if (existing == null) return false;

        existing.Title = taskDto.Title;
        existing.Description = taskDto.Description;
        existing.IsCompleted = taskDto.IsCompleted;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        _tasks.Remove(task);
        return await Task.FromResult(true);
    }
}
