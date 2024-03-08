using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Live.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        readonly DBSqlServerContext _db;
        public TaskRepository (DBSqlServerContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(MyTask task)
        {
           await  _db.AddAsync(task);
           await _db.SaveChangesAsync();
        }

        public async Task<MyTask> GetTaskById(TaskId Id)
        {
             return await _db.Tasks.FindAsync((Guid)Id);
        }
    }
}
