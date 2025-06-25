using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<ActivityDto>> GetAllAsync();
    Task<ActivityDto?> GetByIdAsync(int id);
    Task<ActivityDto> CreateAsync(ActivityDto dto);
    Task<bool> UpdateAsync(int id, ActivityDto dto);
    Task<bool> DeleteAsync(int id);
}
