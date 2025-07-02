using AutoMapper;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Infrastructure.Interfaces;

using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;


public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ActivityDto>> GetAllAsync()
    {
        var activities = await _taskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ActivityDto>>(activities);
    }

    public async Task<ActivityDto?> GetByIdAsync(int id)
    {
        var activity = await _taskRepository.GetByIdAsync(id);
        return activity == null ? null : _mapper.Map<ActivityDto>(activity);
    }

    public async Task<ActivityDto> CreateAsync(ActivityDto dto)
    {
        var activity = _mapper.Map<Activity>(dto);
        var created = await _taskRepository.CreateAsync(activity);
        return _mapper.Map<ActivityDto>(created);
    }

    public async Task<bool> UpdateAsync(int id, ActivityDto dto)
    {
        var activity = _mapper.Map<Activity>(dto);
        activity.Id = id;
        return await _taskRepository.UpdateAsync(activity.Id, activity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _taskRepository.DeleteAsync(id);
    }
}
