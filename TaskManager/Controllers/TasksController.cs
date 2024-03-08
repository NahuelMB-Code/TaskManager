using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectionEntityFramework.Models;
using Microsoft.AspNetCore.Cors;
using ConnectionEntityFramework.TaskDataModel;
using Task = ConnectionEntityFramework.Models.Task;

namespace TaskManager.Controllers
{
    [EnableCors("RulesCord")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // public readonly DBTaskManagementContext _dbTaskManagementContext;

        //public TasksController(DBTaskManagementContext _context)
        //{
        //    _dbTaskManagementContext = _context;

        //}
        public readonly ITaskData<Task> _contextAccessor;

        public TasksController(ITaskData<Task> _taskData) { 

            _contextAccessor = _taskData;
        }


        [HttpGet]
      //  [Route("lista")]
        public IActionResult Get()
        {
           
            List<Task> tasks = new List<Task>();
            try
            {
                tasks = _contextAccessor.Get();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = tasks});

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = tasks });
            }
        }
    }
}
