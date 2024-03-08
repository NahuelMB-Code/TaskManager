using Live.Api.Commands;
using Live.Api.Queries;
using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;

namespace Live.Api.TaskService
{
    public class TaskServices 
    {
        readonly private ITaskRepository _taskRepository;
        readonly private TaskQueries _taskQueries;
        public TaskServices(ITaskRepository taskRepository, TaskQueries taskQueries) 
        {
            _taskRepository = taskRepository;
            _taskQueries = taskQueries;
        }

        public async Task HandleCommand(CreateTaskCm createTaskCm)
        {
            var task = new MyTask(TaskId.Create(createTaskCm.taskId));

            task.SetName(TaskName.Create(createTaskCm.name));

            await _taskRepository.CreateAsync(task);
        }

        public async Task<MyTask> GetTaskAsync(Guid id)
        {
            return await _taskQueries.GetTaskByIdAsync(id);
        }
    }
}
