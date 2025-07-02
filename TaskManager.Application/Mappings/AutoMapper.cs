using AutoMapper;
using TaskManager.Domain.Entities;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Mappings;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<Activity, ActivityDto>();
        CreateMap<ActivityDto, Activity>();

    }
}
