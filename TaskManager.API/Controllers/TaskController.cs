using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Services;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ITaskService taskService, ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("********* Fetching all tasks *********");
        var tasks = await _taskService.GetAllAsync();
        if (tasks == null || !tasks.Any())
        {
            _logger.LogWarning("********* No tasks found *********");
            return NotFound();
        }
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("********* Fetching task with ID: {Id} *********", id);
        var task = await _taskService.GetByIdAsync(id);
        if (task == null)
        {
            _logger.LogWarning("********* Task with ID: {Id} not found *********", id);

            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ActivityDto dto)
    {
        if (dto == null)
        {
            _logger.LogError("********* Received null ActivityDto *********");
            return BadRequest("********* Activity data cannot be null *********");
        }

        var createdTask = await _taskService.CreateAsync(dto);
        if (createdTask == null)
        {
            _logger.LogError("********* Failed to create task *********");
            return BadRequest("********* Failed to create task *********");
        }

        _logger.LogInformation("********* Task created successfully with ID: {Id} *********", createdTask.Id);
        return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ActivityDto dto)
    {
        if (dto == null)
        {
            _logger.LogError("********* Received null ActivityDto for update *********");
            return BadRequest("********* Activity data cannot be null *********");
        }

        var updated = await _taskService.UpdateAsync(id, dto);
        if (!updated)
        {
            _logger.LogWarning("********* Failed to update task with ID: {Id} *********", id);
            return NotFound();
        }

        _logger.LogInformation("********* Task with ID: {Id} updated successfully *********", id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("********* Deleting task with ID: {Id} *********", id);
        var deleted = await _taskService.DeleteAsync(id);
        if (!deleted)
        {
            _logger.LogWarning("********* Failed to delete task with ID: {Id} *********", id);
            return NotFound();
        }

        _logger.LogInformation("********* Task with ID: {Id} deleted successfully *********", id);
        return Ok();
    }
}
