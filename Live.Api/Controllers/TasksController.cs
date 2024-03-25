﻿using Azure;
using Live.Api.Commands;
using Live.Api.TaskService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Live.Api.Controllers
{
    [EnableCors("RulesCord")]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskServices<Guid> _taskService; 

        public TasksController(TaskServices<Guid> taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            object? response = null;

            try
            {
                 response = await _taskService.GetTaskAsync(id);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response });
            }
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] CreateTaskCm<Guid> createTaskCm)
        {

            try
            {
                
                await _taskService.HandleCommand(createTaskCm);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = createTaskCm });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = createTaskCm });
            }
        }

    }
}
