using Microsoft.AspNetCore.Mvc;

namespace Tasks_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskServcie _taskService;

    public TasksController(ITaskServcie taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create( CreatTaskRequest  request)
    {
        var result = await _taskService.CreateAsync(request);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int page = 1, int pageSize = 5)
    {
        var result = await _taskService.GetAllAsync(page, pageSize);

        return Ok(result);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _taskService.GetByIdAsync(id);

        if (result is null)
            return NotFound(new
            {
                message = "Task is not found"
            });

        return Ok(result);
    }

    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateTaskRequest request)
    {
        var result = await _taskService.UpdateAsync(id, request);

        if (result is null)
            return NotFound(new
            {
                message = "Task is not found"
            });

        return Ok(result);
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _taskService.DeleteAsync(id);

        if (!result)
            return NotFound(new
            {
                message = "Task is not found"
            });

        return NoContent();
    }
}
