public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetAllAsync();
    Task<TaskDto?> GetByIdAsync(Guid id);
    Task<TaskDto> CreateAsync(TaskDto taskDto);
    Task<bool> UpdateAsync(Guid id, TaskDto taskDto);
    Task<bool> DeleteAsync(Guid id);
}
