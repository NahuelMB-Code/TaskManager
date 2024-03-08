using ConnectionEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task = ConnectionEntityFramework.Models.Task;


namespace ConnectionEntityFramework.TaskDataModel
{
    internal class TaskData : ITaskData<Task>
    {
        public readonly DBTaskManagementContext _dbTaskManagementContext;

        public TaskData(DBTaskManagementContext _context)
        {
            _dbTaskManagementContext = _context;

        }

        public List<Task> Get()
        {
            return _dbTaskManagementContext.Tasks.ToList();
            // throw new NotImplementedException();
        }

        public List<Task> Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
