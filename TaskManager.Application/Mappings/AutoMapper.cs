using AutoMapper;
using TaskManagerPro.Domain.Entities;
using TaskManagerPro.Infrastructure.Models;

namespace TaskManagerPro.Application.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Task, TaskModel>().ReverseMap();
    }
}
