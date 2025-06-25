using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<ActivityDto>> GetAllAsync();
    Task<ActivityDto?> GetByIdAsync(Guid id);
    Task<ActivityDto> CreateAsync(ActivityDto dto);
    Task<bool> UpdateAsync(Guid id, ActivityDto dto);
    Task<bool> DeleteAsync(Guid id);
}
