using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity?> GetByIdAsync(int id);
    Task<Activity> CreateAsync(Activity task);
    Task<bool> UpdateAsync(int id, Activity task);
    Task<bool> DeleteAsync(int id);
}
