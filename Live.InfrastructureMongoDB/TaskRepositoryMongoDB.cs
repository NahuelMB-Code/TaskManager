using Live.Domain.Entities;
using Live.Domain.Repositories;
using Live.Domain.ValueObjets.Task;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.InfrastructureMongoDB
{
    public class TaskRepositoryMongoDB : ITaskRepository<ObjectId>
    {
        readonly private DBMongoContext _context;

        public TaskRepositoryMongoDB(DBMongoContext context) 
        {
            _context = context;
        }

        public async Task CreateAsync(MyTask<ObjectId> task)
        {
           await _context.Tasks.AddAsync(task);
           await  _context.SaveChangesAsync();
        }

        public async Task<MyTask<ObjectId>> GetTaskById(TaskId<ObjectId> Id)
        {
           return await _context.Tasks.FindAsync((ObjectId)Id);
        }
    }
}
