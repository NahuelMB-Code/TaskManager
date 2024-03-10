using Live.Domain.Entities;
using Live.Domain.ValueObjets.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Entities.MyTask> GetTaskById(TaskId Id);

        System.Threading.Tasks.Task CreateAsync(Entities.MyTask task);
    }
}
