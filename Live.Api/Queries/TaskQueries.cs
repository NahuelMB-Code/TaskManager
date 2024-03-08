using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;

namespace Live.Api.Queries
{
    public class TaskQueries
    {
        readonly private ITaskRepository _taskRepository;
        public TaskQueries(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public Task<MyTask> GetTaskByIdAsync(Guid id)
        {
            var response = _taskRepository.GetTaskById(TaskId.Create(id));

            return Task.FromResult(response.Result);
        }
    }
}
