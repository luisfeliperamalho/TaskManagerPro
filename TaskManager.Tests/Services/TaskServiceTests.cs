using Moq;
using AutoMapper;
using TaskManager.Application.Services;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _repositoryMock = new Mock<ITaskRepository>();
        _mapperMock = new Mock<IMapper>();
        _service = new TaskService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_DeveRetornarDto_QuandoAtividadeExiste()
    {
        // Arrange
        var activityId = 1;
        var activityEntity = new Activity { Id = activityId, Title = "Teste" };
        var activityDto = new ActivityDto { Id = activityId, Title = "Teste" };

        _repositoryMock.Setup(r => r.GetByIdAsync(activityId))
                       .ReturnsAsync(activityEntity);

        _mapperMock.Setup(m => m.Map<ActivityDto>(activityEntity))
                   .Returns(activityDto);

        // Act
        var result = await _service.GetByIdAsync(activityId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(activityDto.Id, result?.Id);
        Assert.Equal(activityDto.Title, result?.Title);

        _repositoryMock.Verify(r => r.GetByIdAsync(activityId), Times.Once);
        _mapperMock.Verify(m => m.Map<ActivityDto>(activityEntity), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_DeveRetornarNull_QuandoAtividadeNaoExiste()
    {
        // Arrange
        var activityId = 99;

        _repositoryMock.Setup(r => r.GetByIdAsync(activityId))
                       .ReturnsAsync((Activity?)null);

        // Act
        var result = await _service.GetByIdAsync(activityId);

        // Assert
        Assert.Null(result);
        _repositoryMock.Verify(r => r.GetByIdAsync(activityId), Times.Once);
        _mapperMock.Verify(m => m.Map<ActivityDto>(It.IsAny<Activity>()), Times.Never);
    }
}
