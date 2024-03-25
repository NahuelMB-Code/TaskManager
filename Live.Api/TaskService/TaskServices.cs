using Live.Api.Commands;
using Live.Api.Queries;
using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;

namespace Live.Api.TaskService
{
    public class TaskServices<T>
    {
        readonly private ITaskRepository<T> _taskRepository;
        readonly private TaskQueries<T> _taskQueries;
        public TaskServices(ITaskRepository<T> taskRepository, TaskQueries<T> taskQueries) 
        {
            _taskRepository = taskRepository;
            _taskQueries = taskQueries;
        }

        public async Task HandleCommand(CreateTaskCm<T> createTaskCm)
        {
    
            var task = new MyTask<T>(TaskId<T>.Create(createTaskCm.TaskId));

            task.SetName(TaskName.Create(createTaskCm.Name));

            await _taskRepository.CreateAsync(task);
        }

        public async Task<MyTask<T>> GetTaskAsync(T id)
        {
            return await _taskQueries.GetTaskByIdAsync(id);
        }
    }
}
