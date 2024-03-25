using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;

namespace Live.Api.Queries
{
    public class TaskQueries<T>
    {
        readonly private ITaskRepository<T> _taskRepository;
        public TaskQueries(ITaskRepository<T> taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public async Task<MyTask<T>> GetTaskByIdAsync(T id)
        {
            var response = _taskRepository.GetTaskById(TaskId<T>.Create(id));

            return await response;
        }
 
    }
}
