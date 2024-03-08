using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionEntityFramework.TaskDataModel
{
    public interface ITaskData<T>
    {
        public List<T> Get();

        public List<T> Get(string name);
    }
}
