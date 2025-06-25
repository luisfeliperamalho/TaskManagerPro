using AutoMapper;
using TaskManager.Domain.Entities;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Activity, ActivityDto>();
        CreateMap<ActivityDto, Activity>();
    }
}
