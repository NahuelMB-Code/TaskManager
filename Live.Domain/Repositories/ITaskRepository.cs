using Live.Domain.Entities;
using Live.Domain.ValueObjets.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.Repositories
{
    public interface ITaskRepository<T>
    {
        Task<MyTask<T>> GetTaskById(TaskId<T> Id);

        Task CreateAsync(MyTask <T> task);
    }
}
