using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;


namespace Live.Infrastructure
{
    public class TaskRepository : ITaskRepository<Guid>
    {
        readonly DBSqlServerContext _db;
        public TaskRepository (DBSqlServerContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(MyTask<Guid> task)
        {
           await  _db.AddAsync(task);
           await _db.SaveChangesAsync();
        }

        public async Task<MyTask<Guid>> GetTaskById(TaskId<Guid> Id)
        {

             return await _db.Tasks.FindAsync((Guid)Id);
          
        }
    }
}
