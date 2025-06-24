using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Services;


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

    public async Task<TaskDto> CreateAsync(TaskDto dto)
    {
        dto.Id = Guid.NewGuid();
        _tasks.Add(dto);
        return await Task.FromResult(dto);
    }

    public async Task<bool> UpdateAsync(Guid id, TaskDto dto)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == id);
        if (existing == null) return false;

        existing.Title = dto.Title;
        existing.Description = dto.Description;
        existing.IsCompleted = dto.IsCompleted;
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
