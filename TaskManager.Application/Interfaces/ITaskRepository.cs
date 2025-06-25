using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity?> GetByIdAsync(Guid id);
    Task<Activity> CreateAsync(Activity task);
    Task<bool> UpdateAsync(Guid id, Activity task);
    Task<bool> DeleteAsync(Guid id);
}
