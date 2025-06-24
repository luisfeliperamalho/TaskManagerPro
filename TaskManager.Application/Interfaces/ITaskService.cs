using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetAllAsync();
    Task<TaskDto?> GetByIdAsync(Guid id);
    Task<TaskDto> CreateAsync(TaskDto dto);
    Task<bool> UpdateAsync(Guid id, TaskDto dto);
    Task<bool> DeleteAsync(Guid id);
}
