using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Services;


public class TaskService : ITaskService
{
    private static readonly List<ActivityDto> _tasks = new();

    public async Task<IEnumerable<ActivityDto>> GetAllAsync()
    {
        return await Task.FromResult(_tasks);
    }

    public async Task<ActivityDto?> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task<ActivityDto> CreateAsync(ActivityDto dto)
    {
        dto.Id = Guid.NewGuid();
        _tasks.Add(dto);
        return await Task.FromResult(dto);
    }

    public async Task<bool> UpdateAsync(Guid id, ActivityDto dto)
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
